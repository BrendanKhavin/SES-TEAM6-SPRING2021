from pymongo import MongoClient


MONGO_URI = "mongodb+srv://simon:xOuSD3LnHbmWIbad@ses2a.wla5p.mongodb.net/ses2a?retryWrites=true&w=majority"
DATABASE = "course-recommend"

def get_degrees():
    client = MongoClient(MONGO_URI)
    db = client[DATABASE]
    return [degree for degree in db.degrees.find()]

def get_students():
    client = MongoClient(MONGO_URI)
    db = client[DATABASE]
    return [student for student in db.students.find()]

def get_subjects():
    client = MongoClient(MONGO_URI)
    db = client[DATABASE]
    return [subject for subject in db.raw_subjects.find()]

def get_topics():
    client = MongoClient(MONGO_URI)
    db = client[DATABASE]
    return [topic for topic in db.keyword_subject_scores.find()]


