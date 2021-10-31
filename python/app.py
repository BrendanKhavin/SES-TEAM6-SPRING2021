import sys
from flask import Flask, jsonify
from models import collaborative, content_based 
from utilities import database


myapp = Flask(__name__)
\
recommender = content_based.Recommender()

ratings_based_recommender = collaborative.RatingsModel()
ratings_based_recommender.train_model()

@myapp.route('/hello/<user_id>')
def say_hello(user_id):
    return "hello"

@myapp.route('/recommend/<user_id>')
def get_recommendations(user_id):
    print(user_id)
    user_prefs = database.get_one_user_preferences(user_id)    
    completed_subjects = database.get_one_completed_subjects(user_id)
    perfect_pref_match_subjects = filter_user_preferences(user_id)
    # So dumb and ineffficent like everything else in this codebase
    build_user_ratings_file()      
    
    # Subject recommendations by comparing user with similar users
    recommendations = []
    # Only do this step if user has rated subjects
    if completed_subjects:
        print('getting rating-based similarity')
        recommendations = ratings_based_recommender.predict_ratings_for_all_users(user_id) 
        print(recommendations)
        
    if len(recommendations) > 10:
        print('filtering preference matches')
        filtered = [sub for sub in recommendations in sub in perfect_pref_match_subjects]
        if filtered < 10:
            filtered.extend([sub for sub in recommendations if sub not in filtered][:10-len(recommendations)])
        recommendations = filtered

    # Subject recommendations based on interest
    if user_prefs and len(user_prefs.get('interests',[])) > 0:
        print('looking at content-based')
        content_recommends = recommender.get_student_recommendation(user_id)
        recommendations.extend([sub for sub in content_recommends if sub not in recommendations and sub not in completed_subjects ])

    # Add popular subjects if required
    k=15
    if len(recommendations) < k:
        print('adding popular subjects')
        # popular_subjects = filter_competed_subjects(user_id, ratings_based_recommender.get_popular_subjects(user_id))
        popular_subjects = ratings_based_recommender.get_popular_subjects(user_id)
        popular_subjects = [sub for sub in popular_subjects if sub in perfect_pref_match_subjects]
        n = min(k-len(recommendations),len(popular_subjects))
        recommendations.extend(popular_subjects[:n])
    

    return jsonify(recommendations)
    

def build_user_ratings_file():
    from utilities import database as db
    userratings = db.get_completed_subjects()
    lines = []
    for r in userratings:
      try:
        lines.append(f"{r['UserId']},{r['SubjectId']},{r['Score']}\n")
      except:
        print(lines[-1])
    with open('data/ratings-model-train-features.csv', 'w') as f:
        f.writelines(lines)
    
def filter_user_preferences(user_id):
    user_prefs = database.get_one_user_preferences(user_id)
    subjects = []
    
    completed_subjects = database.get_one_completed_subjects(user_id)
    if not completed_subjects:
        completed_subjects = []

    for subject in database.get_subjects():
        if subject['code'] in completed_subjects:
            continue
        if user_prefs and filter_subject(subject, user_prefs):
            continue

        subjects.append(subject['code'])

    return subjects
    
def filter_subject(subject, user_prefs=None):
    for assessment in subject['Assessment tasks']:
        atype = assessment.get('Type', None)
        if atype == 'Presentation' and not user_prefs['presentations']:
            return True
        if atype == 'Examination' and not user_prefs['exams']:
            return True
        if atype == 'Essay'  and not user_prefs['essays']:
            return True
        if 'Group' in assessment.get('Groupwork', '') and not user_prefs['groupwork']:
            return True
    return False



run_locally = len(sys.argv) > 1 and sys.argv[1] == "local"
if run_locally:
    myapp.run(
        port=8000,
        debug=True
    )