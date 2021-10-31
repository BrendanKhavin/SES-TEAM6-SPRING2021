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
    return [s for s in db.students.find()]

def get_users():
    client = MongoClient(MONGO_URI)
    db = client[DATABASE]
    return [user['studentId'] for user in db.Users.find()]

def get_user_preferences():
    client = MongoClient(MONGO_URI)
    db = client[DATABASE]
    return [pref for pref in db.UserPreferences.find()]

def get_one_user_preferences(user_id):
    client = MongoClient(MONGO_URI)
    db = client[DATABASE]
    return db.UserPreferences.find_one({"studentId": user_id})

def get_subjects():
    client = MongoClient(MONGO_URI)
    db = client[DATABASE]
    return [subject for subject in db.Subject.find()]

def get_completed_subjects():
    client = MongoClient(MONGO_URI)
    db = client[DATABASE]
    return [subject for subject in db.CompletedSubjects.find()]


def get_one_completed_subjects(user_id):
    client = MongoClient(MONGO_URI)
    db = client[DATABASE]
    return db.CompletedSubjects.find_one({"UserId": user_id})

def get_topics():
    client = MongoClient(MONGO_URI)
    db = client[DATABASE]
    return [topic for topic in db.interests.find()]


