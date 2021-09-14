from string import punctuation

from nltk.corpus import stopwords
import pandas as pd
from sklearn.feature_extraction.text import TfidfVectorizer
import spacy




class Subject:

    def __init__(self, code, name, description, topics):
        self.code = code
        self.name = name
        self.description = description
        self.topics = topics


                    
def remove_noisy_words(text):
    words = {}
    textdoc = nlp(text)

    # ignore tokens that are only verbs
    all_verbs = all([token.pos_ in ["VERB", "ADVERB"] for token in textdoc])
    if all_verbs:
        return words

    for token in textdoc: 
        if token.pos_ not in ["ADP", "SYM", "NUM", "AUX", "CCONJ"]:
            words[token.text] = 1
    return words.keys()


def preprocess_text(text, lemma=False):
    # remove punctuation
    words = [word.strip(punctuation) for word in text.split()]
    
    # remove numbers
    words = [word for word in words if not word.isnumeric()]

    # Lowercase
    words = [word.lower() for word in words]

    # Remove stop words
    words = [word for word in words if word not in stopwords_list]
    
    # Remove linguistically uninformative
    words = remove_noisy_words(" ".join(words))

    # Lemmatise
    if lemma:
        words = " ".join([token.lemma_ for token in nlp(" ".join(words))]).split()
    
    return " ".join(words)


def get_word_scores(docs):
    vectorizer = TfidfVectorizer(ngram_range=(1,2))
    tfidf = vectorizer.fit_transform(docs).toarray()
    tokens = vectorizer.get_feature_names()
    return pd.DataFrame(data=tfidf[:,:],index=codes,columns=tokens)


def get_top_words(word_df, nwords=0):
    if nwords == 0:
        nwords = len(word_df.columns)
    nwords = min(len(word_df.columns), nwords)
    max_col_scores={}
    for col in range(len(word_df.iloc[0,:])):
        col_score = sum(word_df.iloc[:,col])
        max_col_scores[word_df.columns[col]] = col_score
    return sorted(max_col_scores.items(), reverse=True, key=lambda x:x[1])[:nwords]


def is_NaN(value):
    return value != value


def get_subject_list(df):
    codes = df.loc[:,'code']
    names = df.loc[:, 'name']
    descriptions = df.loc[:, 'Description']
    topics = df.loc[:, 'topics']

    subjects = []
    for code, name, description, topic in zip(codes, names, descriptions, topics):
        description = description if not is_NaN(description) else ""
        topic = topic if topic and not is_NaN(topic) else []
        subjects.append(Subject(code, name, description, topic))

    return subjects



if __name__ == "__main__":
    stopwords_list = stopwords.words("english")
    stopwords_list.extend([
        "concept", "concepts", "cover", "covered", "covers", "content", "contents", "include", "includes", "including", "student", 
        "students", "student's", "study", "studies", "studied", "subject", "supervisor", "syllabus", "topic", "topics", "uts", "utsonline"
    ])

    nlp = spacy.load('en_core_web_lg')

    df = pd.read_json("subjects-FEIT.json", orient="index")
    subjects = get_subject_list(df)
    codes = [subject.code for subject in subjects]
    # Extract topics into documents for nlp 
    topic_docs = []
    for subject in subjects:
        # Combine words from all non-None topic items into one array
        subject_topics = " ".join([t for t in subject.topics if t]) 
        topic_docs.append(preprocess_text(subject_topics))

    # Find most informative words in all subject topics
    topic_keyword_df = get_word_scores(topic_docs)
    
    # Find and save the top 1000 keywords
    top_words = get_top_words(topic_keyword_df, 1000)
    with open("top1000_topic_keywords.csv", "w") as f:
        for word, __ in top_words:
            f.write(word + "\n")

    topic_keyword_df.to_pickle("topic_keyword_scores.pkl")


    # Extract descriptions into documents for nlp 
    description_docs = [preprocess_text(subject.description) for subject in subjects]
    description_keyword_df = get_word_scores(description_docs)
    
    # Find and save the top 1000 keywords
    top_words = get_top_words(description_keyword_df, 1000)
    with open("top1000_description_keywords.csv", "w") as f:
        for word, __ in top_words:
            f.write(word + "\n")

    description_keyword_df.to_pickle("description_scores.pkl")


