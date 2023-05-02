import numpy as np
import matplotlib.pyplot as plt

import csv_reader
import datatools as dt
import drawgraphs as dg
import sampleinfo as si


# filename = '/dataset.csv'
# header = si.FEATURES_AND_PRICE
filename = '/dataset_Overall_Defending.csv'
header = si.FEATURES_AND_PRICE_Defending

names, clubs, positions, features, prices = csv_reader.read_dataset(filename)

# features = dt.normalize_z(features)
features = dt.normalize(features)
# log-transformation
prices_log = np.log(prices)

dg.draw_price_number_graph(prices)
dg.draw_price_number_graph(prices_log)


prices = prices_log
# characterizes the existence of a linear relationship between two quantities
pirsquare = np.corrcoef(np.transpose(features), prices)
# create dict with names and corr coef
pirson = [[header[i], pirsquare[i]]
           for i in range(len(header))]
pirson = dict(pirson)


# # correlation with price
# dg.draw_pirson_graph(pirson['Price'])


# # correlation for all features
# for i in range(34):
#     dg.draw_features_correlation(features[:200, i], prices[:200],
#                                  title = si.FEATURES_AND_PRICE[i])


# categorical heatmap
fig, ax = plt.subplots()
im = ax.imshow(pirsquare)

