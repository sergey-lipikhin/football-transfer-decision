import os
import requests
import sampleinfo as si
from bs4 import BeautifulSoup


_namek = si.HEADER_22[0]
_clubk = si.HEADER_22[1]
_positionk = si.HEADER_22[2]
_weakfootk = si.HEADER_22[3]
_skillmovesk = si.HEADER_22[4]
_intrepk = si.HEADER_22[5]
_pricek = si.HEADER_22[6]
_featuresk = si.HEADER_22[7:]


def _print_soup_children(soup):
    print([type(item) for item in list(soup.children)])
    
    
def _get_price(price_string):
    price = '' # all PRICES IN EUROx1000
    for char in price_string.strip()[1:]: # price line
        if char == 'M':  # million
            price = float(price) * 1000
            break
        elif char == 'K':  # thousand
            price = float(price)
            break
        price += char
    return price


def sofifa_get_player(url = 'https://sofifa.com/player/188545/robert-lewandowski/220054/'):

    root = os.path.dirname(os.path.realpath(__file__))+'/html_code/test'
    
    page = requests.get(url)
    # get page content
    soup = BeautifulSoup(page.content, features='html.parser')
    
    # get only tag items that keep features100 
    features100 = soup.select('li span.bp3-tag.p')
    # convert to simple list
    features100 = [l.get_text() for l in features100]
    # convert to dict
    features100 = dict([[_featuresk[i], features100[i]] 
                        for i in range(len(_featuresk))])
    
    player = dict()
    
    name = soup.select('h1', class_='ellipsis')[0].get_text()
    player[_namek] = name
    
    club = soup.select('h5 a')[0].get_text().lstrip()
    player[_clubk] = club
    
    position = soup.select('li span.pos')[1].get_text()
    player[_positionk] = position
    
    weakFoot = \
        soup.select('div.block-quarter div.card ul.pl li.ellipsis')[1].get_text()[0]
    player[_weakfootk] = weakFoot
        
    skillMoves =\
        soup.select('div.block-quarter div.card ul.pl li.ellipsis')[2].get_text()[0]
    player[_skillmovesk] = skillMoves
    
    internationalReputation =\
        soup.select('div.block-quarter div.card ul.pl li.ellipsis')[3].get_text()[0]
    player[_intrepk] = internationalReputation
        
    price = _get_price(soup.select('section div.block-quarter div')[4].get_text())
    player[_pricek] = price
    
    player.update(features100)
    
    return player
