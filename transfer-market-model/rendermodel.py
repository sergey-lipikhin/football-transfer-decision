import os
import numpy as np
import matplotlib.pyplot as plt

from keras.models import Sequential
from keras.layers import Dense
from keras.optimizers import Adam
from keras.optimizers import SGD
from keras.callbacks import EarlyStopping


def model(xtr, ytr, num_epoch=10, batch_size=20, hidden_size=250):
    
    model = Sequential()
    model.add(Dense(hidden_size, activation="relu", input_dim=np.shape(xtr)[1]))
    model.add(Dense(250, activation="relu"))
    model.add(Dense(1, activation="linear"))

    # Compile model
    adam = Adam(learning_rate=1e-3)
    model.compile(loss='mean_squared_error', optimizer=adam)

    # Patient early stopping
    # es = EarlyStopping(monitor='val_loss', mode='min', verbose=1, patience=10)

    # Fit
    history = model.fit(xtr, ytr, epochs=num_epoch, batch_size=batch_size,
                        verbose=1)
                        # callbacks=[es], validation_split=0.15, shuffle=True)
                        
    # for layer in model.layers: print(layer.get_weights())
                        
    # Save model
    model.save(os.path.dirname(os.path.realpath(__file__))+'/ready_models/Test_Model.h5')

    plt.plot(history.history['loss'], label='train')
    plt.title('Динаміка навчання')
    plt.xlabel('Ітерація')
    plt.ylabel('Помилка')
    # plt.plot(history.history['val_loss'], label='validate')
    plt.legend()
    plt.show()
