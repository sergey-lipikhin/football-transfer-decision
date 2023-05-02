import csv
import os
import numpy as np
from itertools import tee
    

def read_dataset(filename = 'dataset.csv'):
    with open(os.path.dirname(os.path.realpath(__file__))+'/csv_files/' + filename
              , encoding="utf8") as f:
        # read
        csv_reader = csv.reader(f, delimiter=',')
        # not include header
        next(csv_reader, None)
        # csv-list comprehension method of packing data.
        # create two iterators
        i1, i2, i3, i4, i5 = tee(csv_reader, 5)
        # personal info: name, club, pos
        names = np.array([[data[0]] for data in i1])
        clubs = np.array([[data[1]] for data in i2])
        positions = np.array([[data[2]] for data in i3])
        # features 1-5 0-100
        features = np.array([[float(d) for d in data[4:7] + data[7:]] for data in i4])
        # prices
        prices = []
        [prices.extend([float(d) if '0Value' not in str(d) else float(0)
                        for d in data[3:4]]) for data in i5]
        prices = np.asarray(prices)
        return names, clubs, positions, features, prices
