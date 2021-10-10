import json
import random

import names
import numpy as np 
import pandas as pd
from pymongo import MongoClient


client = MongoClient("mongodb+srv://simon:xOuSD3LnHbmWIbad@ses2a.wla5p.mongodb.net/ses2a?retryWrites=true&w=majority")
db = client["course-recommend"]
degrees = {degree['code']: degree for degree in db.degrees.find()}
subjects = {subject['code']: subject for subject in db.raw_subjects.find()}
noncombined_degrees = {degree['code']: degree for degree in db.degrees.find({"combined_degree": False})}

n_students = 100
student_ids = np.arange(10000000, 10000000 + n_students)

topics = []
with open('data/selected_topic_keywords.csv', 'r') as f:
    topics = [topic.strip('\n') for topic in f.readlines()]

def get_pseudorandomdegree():
    # only 20% of students should be in combined degree
    if random.random() > 0.8:
        degree = random.choice(list(degrees.values()))
    else:
        degree = random.choice(list(noncombined_degrees.values()))
    return {
        'code': degree['code'],
        'name': degree['name'],
        'major': random.choice(degree['majors']).strip() if degree['majors'] else None
    }

def get_subjects_completed(degree_code):
    degree_subjects = [subjects[code] for code in degrees[degree_code]['subjects'] if code in subjects]
    return [
        {
            'code': subject['code'],
            'name': subject['name'],
            'credit_points': subject['Credit Points'],
            'rating': int(np.random.choice(
                [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
                p=[0.01, 0.02, 0.02, 0.05, 0.1, 0.2, 0.2, 0.2, 0.1, 0.1]))

        } for subject in random.sample(degree_subjects, random.choice([0, min(2,len(degree_subjects), min(4, len(degree_subjects)), min(8, len(degree_subjects)))]))
    ]

def get_random_interests():
    return random.sample(topics, 10)

def get_preferences():
    return {
        "groupwork": random.randint(0,1),
        "essays": random.randint(0,1),
        "presentations": random.randint(0,1),
        "exams": random.randint(0,1)
    }

students = []
for sid in student_ids:
    degree = get_pseudorandomdegree()
    student = {
        "id": str(sid),
        "name": names.get_full_name(),
        "degree": degree,
        "completed_subjects": get_subjects_completed(degree['code']),
        "preferences": get_preferences(),
        "interests": get_random_interests(),
        "international_student": random.randint(0,1)
    }
    students.append(student)

with open('data/students.json' ,'w') as f:
    json.dump(students, f)