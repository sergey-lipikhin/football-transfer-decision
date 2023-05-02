import matplotlib.pyplot as plt
import sampleinfo as si


def draw_price_number_graph(prices):
    plt.figure(figsize=(9, 10))
    plt.hist(prices, edgecolor='black')
    plt.title('Ціновий розподіл', fontsize=24)
    plt.xlabel('€', fontsize=19)
    plt.ylabel('N', fontsize=19)
    plt.show()
    
    
def draw_pirson_graph(pirson):
    plt.figure(figsize=(10, 7))
    plt.barh(si.FEATURES_AND_PRICE_UKR, pirson, color='slateblue')
    plt.title('Коефіцієнт кореляції Пірсона', fontsize=24)
    plt.xticks(fontsize=12)
    plt.yticks(fontsize=8)
    plt.show()
    

def draw_features_correlation(x, y, title = 'Correlation'):
    plt.plot(x, y, 'r.')
    plt.title(title)
    plt.xlabel('Independent ')
    plt.ylabel('Dependent ')
    plt.show()
    plt.close()
