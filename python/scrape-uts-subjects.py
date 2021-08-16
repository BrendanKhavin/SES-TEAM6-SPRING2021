import re
import requests
from pprint import pprint

from bs4 import BeautifulSoup
from pymongo import MongoClient


def get_request(url):
    header = {
        "user-agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.169 Safari/537.36",
        "referer": "https://www.google.com/",
    }

    return requests.get(
        url,
        headers=header,
    )


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
    soup = get_soup(f"https://handbook.uts.edu.au/subjects/{code}.html")
    sessions = re.findall("\w+ session", soup.get_text())
    return [session.replace("campus", "") for session in sessions]


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
            subject_details["Requisites"] = str(em.text).split("Requisite(s): ")[1]
        if "Anti-requisite(s)" in str(em):
            subject_details["Anti-requisites"] = str(em.text).split(
                "Anti-requisite(s): "
            )[1]
        if "Result type" in str(em):
            subject_details["Result type"] = em.next_sibling.split(":")[1]

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


course_area_url_keys = {
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

# Storing in local database
client = MongoClient("mongodb://localhost:27017/")
db = client["ses2a"]

subject_catalogue = {}

# Get subject codes from all course areas
for key, area in course_area_url_keys.items():
    subjects = get_course_subject_list(key)
    for subject in subjects:
        subject_catalogue[subject] = subject_catalogue.get(subject, {})
        # A subject can only be in one course area
        subject_catalogue[subject]["course_area"] = area

# Get subject details for each code
for subject_code in subject_catalogue.keys():
    subject_details = get_subject_details(subject_code)
    for k, v in subject_details.items():
        subject_catalogue[subject_code][k] = v

    db["subjects"].insert_one(subject_catalogue[subject_code])
