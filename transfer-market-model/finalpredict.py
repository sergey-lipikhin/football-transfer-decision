import os
import sys
import numpy as np
from keras.models import load_model


def normalize(features):
    x_min = np.array([1,1,1,54,15,8,6,7,10,5,8,9,7,12,11,20,18,21,26,20,22,26,
                      19,11,5,10,8,3,13,11,11,])
    x_max = np.array([5,5,5,91,93,94,95,93,94,95,96,93,94,95,96,97,97,94,95,96,
                      95,96,97,95,95,94,93,96,95,93,91])
    return (features - x_min) / (x_max - x_min)


model = load_model(os.path.dirname(os.path.realpath(__file__))+'/ready_models/final/FINAL_patience10.h5')

# mbape
# features = '4.0,5.0,4.0,85.0,92.0,78.0,93.0,72.0,85.0,83.0,93.0,80.0,69.0,71.0,91.0,'\
#     '97.0,97.0,92.0,93.0,83.0,86.0,78.0,88.0,77.0,82.0,62.0,38.0,92.0,82.0,79.0,49.0'
    
features = sys.argv[1]

# from string to np.array
features = np.array([float(value) for value in features.split(',')])
# normalize
features = normalize(features)
# for predict() input format
features = np.array([features])


prediction = model.predict(features, verbose = 0)
#convert from log-transform to euros
prediction = np.round(np.power(np.exp(1), prediction))
# take first element
prediction = prediction[0][0]

print(prediction)
