import numpy as np
import matplotlib.pyplot as plt

import csv_reader
import datatools as dt
import drawgraphs as dg
import sampleinfo as si


names, clubs, positions, features, prices = csv_reader.read_dataset()

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
pirson = [[si.FEATURES_AND_PRICE[i], pirsquare[i]]
           for i in range(len(si.FEATURES_AND_PRICE))]
pirson = dict(pirson)


# correlation with price
dg.draw_pirson_graph(pirson['Price'])


# # correlation for all features
# for i in range(34):
#     dg.draw_features_correlation(features[:200, i], prices[:200],
#                                  title = si.FEATURES_AND_PRICE[i])


# categorical heatmap
fig, ax = plt.subplots()
im = ax.imshow(pirsquare)
# Create colorbar
cbar = ax.figure.colorbar(im, ax=ax)
cbar.ax.set_ylabel('Сила зв\'язку', rotation=-90, va="bottom")
ax.set_title('Карта кореляції ознак')

# categorical heatmap for problem interval
pirsquare = pirsquare[29:-1, 29:-1]
fig, ax = plt.subplots()
im = ax.imshow(pirsquare)
# Create colorbar
cbar = ax.figure.colorbar(im, ax=ax)
cbar.ax.set_ylabel('Сила зв\'язку', rotation=-90, va="bottom")
# Show all ticks and label them with the respective list entries
x_label = ['Пенальті','Самовладання','Гра по супернику','Відбір','Підкат']
y_label = x_label
ax.set_xticks(np.arange(len(x_label)), labels=x_label)
ax.set_yticks(np.arange(len(y_label)), labels=y_label)
plt.setp(ax.get_xticklabels(), rotation=45, ha='right',
         rotation_mode='anchor')
# Loop over data dimensions and create text annotations.
for i in range(len(x_label)):
    for j in range(len(y_label)):
        text = ax.text(j, i, '{:.2f}'.format(pirsquare[i, j]),
                       ha="center", va="center", color="w")
ax.set_title('Карта кореляції ознак')
