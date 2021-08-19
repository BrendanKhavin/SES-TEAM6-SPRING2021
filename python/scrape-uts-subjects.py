import json 
import re
import requests

from bs4 import BeautifulSoup
from pymongo import MongoClient


def get_soup(url):
    header = {
        "user-agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.169 Safari/537.36",
        "referer": "https://www.google.com/",
    }
    page = requests.get(
        url,
        headers=header,
    )
    return BeautifulSoup(page.content, "html.parser")


def get_subject_availability(code):
    valid_sessions = [
        'Autumn session',
        'Spring session',
        'Summer session',
        'Winter session',
        'January session',
        'February session',
        'March session',
        'April session',
        'May session',
        'June session',
        'July session',
        'August session',
        'September session',
        'October session',
        'November session',
        'December session',

    ]
    page_text = get_soup(f"https://handbook.uts.edu.au/subjects/{code}.html").get_text()
    available = []
    for session in valid_sessions:
        if re.findall(session, page_text):
            available.append(session)
    return available


def get_subject_details(code):
    soup = get_soup(f"https://handbook.uts.edu.au/subjects/details/{code}.html")
    subject_details = {}
    # Code and subject name: the only `h1` on the page
    code, name = soup.find("h1").text.split(" ", 1)
    subject_details["code"] = code
    subject_details["name"] = name

    for em in soup.find_all("em"):
        if "Credit points" in str(em):
            subject_details["Credit Points"] = em.next_sibling.split(" ")[1] 
        if "Requisite(s)" in str(em):
            # Requires a parser for the grammer  UTS uses but for now just store as string
            # requisites = parse_requisites(str(em.text).split("Requisite(s): ")[1])
            subject_details["Requisites"] = (str(em.text).split("Requisite(s): ")[1]).strip()
        if "Anti-requisite(s)" in str(em):
            subject_details["Anti-requisites"] = (str(em.text).split(
                "Anti-requisite(s): "
            )[1]).strip()
        if "Result type" in str(em):
            subject_details["Result type"] = (str(em.next_sibling.split(":")[1])).strip()

    for h3 in soup.find_all("h3"):
        if "Description" in h3:
            # subject_details["description"] = h3.next_sibling.next_sibling
            rest_of_page = (
                h3.next_sibling.next_sibling  # They fucked up with an unclosed <p> element
            )
            it = iter(rest_of_page.contents)
            description = ""
            for element in it:
                if element.name == "p" and element.string:
                    description += element.string + "\n"
                elif element.name == "ul":
                    for li in element.find_all("li"):
                        if li.string:
                            description += li.string + "\n"
            subject_details["Description"] = description

        if "Content (topics)" in h3:
            rest_of_page = (
                h3.next_sibling.next_sibling
            )  # They fucked up with an unclosed <p> elements
            it = iter(rest_of_page.contents)
            topics = []
            for element in it:
                if element.name == "p" and element.string:
                    topics.append(element.string)
                elif element.name == "ul":
                    for li in element.find_all("li"):
                        topics.append(li.string)
            subject_details["topics"] = topics

    sloTable = soup.select("[class~=SLOTable]")
    if sloTable:
        subject_details["SLOs"] = [td.string for td in sloTable[0].find_all("td")]

    ciloTable = soup.select("[class~=CILOList]")
    if ciloTable:
        subject_details["CILOs"] = [li.string for li in ciloTable[0].find_all("li")]

    assessment_tasks = []
    for task in soup.select("[class=assessmentTaskTable]"):
        task_details = {}
        attributes = ["Type", "Groupwork", "Weight", "Length"]
        for row in task.find_all("tr"):
            if not row.th:
                continue
            for attribute in attributes:
                if attribute in row.th.text:
                    task_details[attribute] = row.td.text.strip()
        assessment_tasks.append(task_details)
    subject_details["Assessment tasks"] = assessment_tasks
    subject_details["Availability"] = get_subject_availability(code)

    return subject_details


def get_course_subject_list(course_key):
    subject_list_url = (
        f"https://www.handbook.uts.edu.au/{course_key}/lists/numerical.html"
    )
    soup = get_soup(subject_list_url)

    subject_list = []
    for a in soup.select("[class=ie-images]")[0].find_all("a"):
        if "https://handbook.uts.edu.au/subjects/" not in str(a):
            continue
        subject_code = a.string
        subject_list.append(subject_code)
    return subject_list


def export_to_mongodb(host, db_name, data):
    client = MongoClient(host)
    db = client[db_name]
    # Storing in local database
    for code, details in subject_catalogue.items():
        db["subjects"].insert_one(subject_catalogue[code])


def export_as_json(data, filename="subjects.json"):
    with open(filename, 'w') as f:
        json.dump(data, f)




course_areas = {
    "ads": "Analytics and Data Science",
    "bus": "Business",
    "comm": "Communication",
    "cii": "Creative Intelligence and Innovation",
    "dab": "Design, Architecture and Building",
    "edu": "Education",
    "eng": "Engineering",
    "health": "Health",
    "health-gem": "Health (GEM)",
    "it": "Information Technology",
    "intl": "International Studies and Social Sciences",
    "law": "Law",
    "sci": "Science",
    "tdi": "Transdisciplinary Innovation",
}
 

# Get subject details for engineering and IT
catalogue = {}
subjects = get_course_subject_list("")
for course_key in ["eng", "it"]:
    subjects = get_course_subject_list(course_key)
    for subject_code in subjects:
        subject_details = get_subject_details(subject_code)
        subject_details["course area"] = course_areas[course_key]
        catalogue[subject_code] = subject_details
        print(subject_details)

export_as_json(catalogue)

  



# export_to_mongodb(client, db, aubject_catalogue)


