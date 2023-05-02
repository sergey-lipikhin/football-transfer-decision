import os
import csv
import numpy as np
import sampleinfo as si
from itertools import tee


def _read_source_csv():
    """ Read and template data from /data/dataset/source.csv after multiple
    html-requests for each player from website sofifa.com"""
    with open(os.path.dirname(os.path.realpath(__file__))+'/data/dataset/source.csv'
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
        features = np.array([[float(d) for d in data[3:6] + data[7:]] for data in i4])
        # prices
        prices = []
        [prices.extend([float(d) if '0Value' not in str(d) else float(0)
                        for d in data[6:7]]) for data in i5]
        prices = np.asarray(prices)
        return names, clubs, positions, features, prices


def _generalize_position(positions):
    """ Too many positions need to be replaced by only 'GK' 'MF' 'FW' 'GK'"""
    
    keygk  = ['GK']
    keydef = ['CB', 'LB', 'RB', 'RWB', 'LWB', 'LCB', 'RCB']
    keymid = ['CM', 'CDM', 'CAM', 'RM', 'LM', 'LCM', 'RCM', 'LDM', 'RDM']
    keyfor = ['ST', 'CF', 'RW', 'LW', 'RF', 'LF', 'LS', 'RS']
    left   = ['RES' 'SUB']
    
    for i in range(len(positions)):
        if positions[i] in keygk:
            positions[i] = 'GK'
        elif positions[i] in keydef:
            positions[i] = 'DF'
        elif positions[i] in keymid:
            positions[i] = 'MF'
        elif positions[i] in keyfor:
            positions[i] = 'FW'
        else:
            positions[i] = 'MF'
            
    return positions


def _formatate_table(table):
    """ Some manipulations with data"""  
    
    # unique rows handler
    repeats = dict()
    final = []
    for row in table:
        # remove player with 0 transfer value
        if float(row[3]) == 0:
            continue
        # remove GK
        if str(row[2]) == 'GK':
            continue
        # remove repeated names
        if row[0] not in repeats:
            final.append(row)
            repeats[row[0]] = True

    return np.array(final)


# read data frm source file
names, clubs, positions, features, prices = _read_source_csv()

# generalize players positions
positions = _generalize_position(positions)

# transform 1-row array into 1-column array
names = names.reshape(len(names), 1)
clubs = clubs.reshape(len(clubs), 1)
positions = positions.reshape(len(positions), 1)
prices = prices.reshape(len(prices), 1)

# concatanate arrays and got table
table = np.append(names, clubs, axis=1)
table = np.append(table, positions, axis=1)
table = np.append(table, prices, axis=1)
table = np.append(table, features, axis=1)

# remove all redundant table info
table = _formatate_table(table)

# write final dataset into file
with open('./csv_files/dataset.csv', 'w', encoding='UTF8', newline='') as f:
    writer = csv.writer(f)
    writer.writerow(si.HEADER_22)
    writer.writerows(table) 
