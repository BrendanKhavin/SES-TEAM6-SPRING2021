from bs4 import BeautifulSoup
import csv
import pprint
import re
import requests
import json


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

# Count occurences of each subject code on the degrees handbook page
def page_subject_frequencies(page):
    def subject_code(a):
        return a and re.compile('^\d{5}').search(a)
    codes = [a.text for a in page.find_all('a') if subject_code(a.text)]
    freqs = {}
    for code in codes:
        freqs[code] = freqs.get(code, 0) + 1
    return freqs
    
def get_degree_majors(page):
    def is_major_code(a):
        return a and re.compile('^MAJ\d{5}').search(a)
    major_codes = [(a.text, a.next_sibling) for a in page.find_all('a') if is_major_code(a.text)]
    if not major_codes:
        # look harder
        major_choice = [a.text for a in page.find_all('a') if "CBK" in a.text and "Major choice" in str(a.next_sibling)]
        for choice in major_choice:
            url = f"https://handbook.uts.edu.au/directory/cbk{choice[3:]}.html"
            choice_page = get_soup(url)
            major_codes = [(a.text, a.next_sibling.string.strip("\xa0")) for a in choice_page.find_all('a') if is_major_code(a.text)]
    return major_codes

degrees = {}
with open("data/degrees.csv", encoding='utf-8') as f:
    csvReader = csv.DictReader(f)
    for rows in csvReader:
        degrees[rows['code']] = rows

for degree in degrees:
    url = f"https://handbook.uts.edu.au/courses/c{degree[1:]}.html"
    soup = get_soup(url)
    
    subject_freqs = page_subject_frequencies(soup)
    subject_freqs = sorted([s for s in subject_freqs], key=lambda s: subject_freqs[s], reverse=True)
    
    majors = get_degree_majors(soup)
    
    degrees[degree]['majors'] = [major[1] for major in majors]
    degrees[degree]["subjects"] = [subject_freqs[i] for i in range(min(10,len(subject_freqs)))]


with open("data/degrees.json", 'w') as f:
    json.dump(degrees,f)

