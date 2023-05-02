import sys
sys.path.append('sofifa')

import csv
import numpy as np

import hrefs
import player
import sampleinfo as si


_root = './sofifa/data/dataset/'

def _write_players_in_file(players):
    with open(_root + 'source.csv', 'w', encoding='UTF8', newline='') as f:
        writer = csv.writer(f)
        writer.writerow(si.HEADER_22)
        writer.writerows(players)


def _write_errors_in_file(errors):
    with open(_root + 'errors.csv', 'w', encoding='UTF8', newline='') as f:
        [f.write(error + '\n') for error in error_players]
    


def get_players(players_number):
    """Itarate throw hrefs/players.txt file and request fifa website to get
        all neccessary info about players"""
        
    url = 'https://sofifa.com'
    playeref = hrefs.read_hrefs_from_file()
    
    if players_number < 0 or players_number > len(playeref):
        players_number = len(playeref)
    
    players = []
    error_players = []
    for i in range(0, players_number):
        print('Reading player #{0} on {1}'.format(i, playeref[i]))
        
        try:
            players.append(list(player.sofifa_get_player(url + playeref[i]).values()))
        except:
            error_players.append(playeref[i])
            pass
            
    return np.array(players), np.array(error_players)
    

# players, error_players = get_players(17979)
# _write_players_in_file(players)
# _write_errors_in_file(error_players)
