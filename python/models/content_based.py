from utilities import database as db
import json
import pandas as pd


class Student:
    def __init__(self, student, topics):
        self.id = student['id']
        self.name = student['name'] 
        self.preferences = student['preferences']
        self.interests = student['interests']
        self.interest_vector = [int(list(topic.keys())[1] in student['interests']) for topic in topics]
        self.degree = student['degree']
        self.major = student['degree']['major']
        self.completed_subjects = student['completed_subjects']

class Subject:
    def __init__(self, subject, tfidfs):
        self.code = subject['code']
        self.name = subject['name']
        self.topic_vector = list(tfidfs.loc[[subject['code']]].values.flatten().tolist())


class kNNStudentSubject:
    def __init__(self, students, subjects, topics, tfidfs, k=5):
        self.students = [Student(student, topics) for student in students]
        self.subjects = [Subject(subject, tfidfs) for subject in subjects]
        self.student_index = {student.id: i for i, student in enumerate(self.students)}
        self.k = k
    
    def get_neighbours(self, student_id):
        student = self.students[self.student_index[student_id]]
        interest_scores = interest_similarities(student,self.subjects)
        nearest_k = sorted(interest_scores, key=lambda x: x[1], reverse=True)[:self.k]
        return nearest_k

def cosine_similarity(a, b):
    def dot_product(a, b):
        return sum([a[i]*b[i] for i in range(len(a))])

    def magnitude(v):
        return sum([x**2 for x in v])**0.5
    
    magnitude_product = magnitude(a) * magnitude(b)

    if magnitude_product:
        return dot_product(a, b) / magnitude_product 
    else: 
        return 0
    

def interest_similarities(student, subjects):
    return [(subject.code, cosine_similarity(student.interest_vector, subject.topic_vector)) for subject in subjects]


class Recommender:
    def __init__(self):
        self.subject_topic_tfidfs = pd.read_pickle('data/selected_topic_keyword_scores.pkl')
        self.subject_topic_tfidfs.index = self.subject_topic_tfidfs.index.map(str)
        self.subjects = db.get_subjects()
        self.topics = db.get_topics()

            
    def get_student_recommendation(self, student_id):
        students = db.get_students()
        kNN_student_subject = kNNStudentSubject(students, self.subjects, self.topics, self.subject_topic_tfidfs)
        neighbours = kNN_student_subject.get_neighbours(student_id)
        result = [code for (code,score) in neighbours]
        return result[:min(5, len(neighbours))]  