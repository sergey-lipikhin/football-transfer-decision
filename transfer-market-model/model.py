import csv_reader
import datatools as dt
import numpy as np

import os
import matplotlib.pyplot as plt
from keras.models import load_model

from sklearn.metrics import r2_score


names, clubs, positions, features, prices = csv_reader.read_dataset('/dataset_Overall_Defending.csv')

features = dt.normalize(features)
# natural logarithm
prices = np.log(prices)

features, prices = dt.shuffle_data(features, prices)
xtr, ytr, xte, yte = dt.split_data(features, prices)

# no Reaсtion, Ball Control, Potential
# features = np.concatenate((features[:,:3], features[:,4:13],
#                             features[:,14:16], features[:,17:]), axis=1)

import rendermodel as rm

# LOOP FOR HIDDEN LAYER SIZE
# result = []
# for i in range(1,50):
    
#     hidden_size = i*25
    
#     model = rm.model(xtr, ytr, num_epoch=30, batch_size=20, hidden_size=50)
#     pte = model.predict(xte)
#     r2 = r2_score(yte,pte)
#     result.append([r2, hidden_size])

model = rm.model(xtr, ytr, num_epoch=30, batch_size=20, hidden_size=625)

model = load_model(os.path.dirname(os.path.realpath(__file__))+'/ready_models/Test_Model.h5')

ptr = model.predict(xtr)
pte = model.predict(xte)

plt.plot(yte,pte,'r.')
plt.title('Тестова вибірка')
plt.xlabel('Фактичне')
plt.ylabel('Прогнозоване')

r21 = r2_score(ytr,ptr)
r2 = r2_score(yte,pte)
