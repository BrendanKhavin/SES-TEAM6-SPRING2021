from collections import defaultdict
from surprise import Dataset, Reader
from surprise.model_selection import train_test_split
from surprise.prediction_algorithms import knns
import pickle

class RatingsModel:
  def __init__(self):
    self.TRAIN_PATH = 'data/ratings-model-train-features.csv'
    self.TEST_PATH = 'data/ratings-model-test-features.csv'
    self.model = knns.KNNBasic()
    self.K = 10


  def load_ratings(self, dataset_label):
    reader = Reader(sep=',',rating_scale=(1,10))
    if dataset_label == 'TRAIN':
      try:          
        data = Dataset.load_from_file("data/ratings-model-features.csv", reader=reader)

        self.data = data
        self.trainset = data.build_full_trainset()
        self.subjects = list(set([x[1] for x in self.trainset.build_testset()]))
        self.users = list(set([x[0] for x in self.trainset.build_testset()]))
      except:
        print('failed to load train data')
    elif dataset_label == 'LIVE':
      try:          
        data = Dataset.load_from_file("data/ratings-model-features.csv", reader=reader)
      except:
        print("failed to load test data")      

  def predict_ratings_for_all_users(self, user_id, subjects=[]):
    self.load_ratings('LIVE')
    if not subjects:
      subjects = self.subjects
    predictions = [self.model.predict(user_id, subject_id, 1) for subject_id in subjects]

    # predictions = [self.model.predict(user_id, subject_id, 1) for subject_id in self.subjects]
    top_k_predictions = self.get_top_predictions(predictions, self.K)
    # return top_k_predictions[user_id]
    return [s[0] for s in top_k_predictions[user_id]][:10]

  def get_top_predictions(self, predictions, K=10):
    user_mapped_preds = defaultdict(list)
    for user_id, subject_id, true_r, est, _ in predictions:
      user_mapped_preds[user_id].append((subject_id, est))

    for user_id, rating in user_mapped_preds.items():
      rating.sort(key=lambda x: x[1], reverse=True)

    return user_mapped_preds

  def load_model(self):
    with open('data/model.pkl', 'r') as f:
      self.model = pickle.load(f)

  def train_model(self):
    self.load_ratings('TRAIN')
    self.model.fit(self.trainset)

  def get_popular_subjects(self, student_id):
    exclude = []
    user_ratings = defaultdict(list)
    for user_rating in self.trainset.build_testset():
      user_ratings[user_rating[1]].append(user_rating[2])
      if user_rating[0] == student_id:
        exclude.append(user_rating[1])
    subject_rating_averages = [(subject, (sum(ratings)/len(ratings))) for subject,ratings in user_ratings.items()]
    subject_rating_averages.sort(key=lambda x: x[1], reverse=True)
    popular = [subject for (subject,rating) in 
      subject_rating_averages if rating > 2 and subject not in exclude]
    print(popular)
    return popular
    