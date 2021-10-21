from flask import Flask, jsonify
from models import content_based 



myapp = Flask(__name__)

recommender = content_based.Recommender()

@myapp.route('/recommend/<user_id>')
def get_recommendations(user_id):
    recommendations = recommender.get_student_recommendation(user_id)
    return jsonify(recommendations)

run_locally = False
if run_locally:
    myapp.run(
        port=8000,
        debug=True
    )