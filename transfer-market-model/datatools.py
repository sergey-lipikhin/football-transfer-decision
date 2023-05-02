import numpy as np
import sampleinfo as si


def normalize(features):
    """Normalization or Min-Max Scaling"""
    x_min = np.min(features, axis=0)
    x_max = np.max(features, axis=0)
    # get values from 0 to 1    
    return (features - x_min) / (x_max - x_min)
    

def normalize_z(features):
    """Standardization or Z-Score Normalization"""
    # simple mean value of each feature
    mu = np.mean(features, axis=0)
    # standard deviation (with N in denominator, not N-1)
    sigma = np.std(features, axis=0)
    return (features - mu) / sigma


def shuffle_data(features, prices):
    """ Shuffle features """
    np.random.seed(0)  # To maintain consistency across runs
    perm = np.random.permutation(si.NUM_TOTAL)
    temp_features = np.zeros_like(features)
    temp_prices = np.zeros_like(prices)
    for i in range(len(perm)):
        temp_features[i, :] = features[perm[i], :]
        temp_prices[i] = prices[perm[i]]
    return temp_features, temp_prices


def split_data(features, prices):
    """ Separate into training and test """
    xtr = features[:si.NUM_TRAIN, :]
    ytr = prices[:si.NUM_TRAIN]
    xte = features[si.NUM_TRAIN:, :]
    yte = prices[si.NUM_TRAIN:]
    return xtr, ytr, xte, yte
