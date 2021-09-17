import pandas as pd
from sklearn.neighbors import KNeighborsRegressor
from sklearn.model_selection import train_test_split
from sklearn.metrics.pairwise import cosine_similarity
from scipy import spatial, sparse
from pprint import pprint
import numpy as np



subjects = pd.read_json("subjects-FEIT.json", orient="index")
codes = subjects.loc[:,'code'].tolist()
names = subjects.loc[:, 'name'].to_list()
subjects_by_code = {code: name for code, name in zip(codes, names)}


topic_df = pd.read_pickle("topic_keyword_scores.pkl")
description_df = pd.read_pickle("description_keyword_scores.pkl")
result = {}
 
topic_similarity = pd.DataFrame(data=cosine_similarity(topic_df, topic_df), index=codes, columns=codes)
description_similarity = pd.DataFrame(data=cosine_similarity(description_df, description_df),  index=codes, columns=codes)

def get_total_similarity(subject_code1, subject_code2):  
    topic_sim = topic_similarity[subject_code1][subject_code2]
    description_sim = description_similarity[subject_code1][subject_code2]
    summed_sim = topic_sim + description_sim
    return summed_sim if topic_sim == 0 or description_sim == 0 else summed_sim / 2
    

n_subjects = len(codes)
for i in range(n_subjects):
    similarities = []
    for j in range(n_subjects):
        similarities.append(get_total_similarity(codes[i], codes[j]))
        
    print(subjects_by_code[codes[i]])
    pprint([names[j] for j in np.argsort(np.array(similarities))[::-1][:10]])
    print("-----------")

# description_similarity.to_csv("description_cosine.csv")
# keyword_similarity.to_csv("keyword_cosine.csv")
