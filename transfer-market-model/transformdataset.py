import os
import csv
import numpy as np
from itertools import tee
import sampleinfo as si


""" Form dataset without Overall
But Defensive Awareness,Standing Tackle,Sliding Tackle as one Defending """ 
with open(os.path.dirname(os.path.realpath(__file__))+'/csv_files/dataset.csv'
          , encoding="utf8") as f:
    # read
    csv_reader = csv.reader(f, delimiter=',')
    # not include header
    next(csv_reader, None)
    # csv-list comprehension method of packing data.
    # create two iterators
    i1, i2 = tee(csv_reader, 2)
    # all but -4 features
    features = np.array([[d for d in data[0:7] + data[8:-3]] for data in i1])
    # Defensive Awareness, Standing Tackle, Sliding Tackle
    defending = np.array([[float(d) for d in data[-3:]] for data in i2])
    defending = np.round([[np.mean(d)] for d in defending])
    
    table = np.append(features, defending, axis=1)
    
    header = si.HEADER_22[0:7] + si.HEADER_22[8:-3]
    header.append('Defending')
    
    with open('./csv_files/dataset_Overall_Defending.csv', 'w', encoding='UTF8', newline='') as f:
        writer = csv.writer(f)
        writer.writerow(header)
        writer.writerows(table) 
    