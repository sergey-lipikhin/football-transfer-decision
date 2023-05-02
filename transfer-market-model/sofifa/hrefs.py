import os
import requests
import numpy as np
from bs4 import BeautifulSoup


# number of pages to read
_numberOfpages = 300
# hrefs list directory
filename = os.path.dirname(os.path.realpath(__file__))+'/data/hrefs/players.txt'


def _get_hrefs(numberOfpages):
    
    url = 'https://sofifa.com/players?r=220001&set=true&offset='
    
    hrefs = []
    # iterate throw pages by changing offset
    for i in range(numberOfpages):
        # get offset
        offset = i*60
        # request html page
        page = requests.get(url + str(offset))
        # get text from page
        soup = BeautifulSoup(page.content, features='html.parser')
        html = list(soup.children)[2]
        body = list(html.children)[3]
    
        for a in body.select('td.col-name a', href=True):
            if '/player/' in str(a):
                hrefs.append(a['href'])
        # to view progress
        print("Itteration #{0} with offset = {1}".format(i, offset))
    
    return hrefs


def _write_hrefs_in_file(hrefs):
    with open(filename, 'w') as f:
        [f.write(href + '\n') for href in hrefs]


def read_hrefs_from_file():
    with open(filename, 'rt') as f:
        hrefs = f.readlines()
        # delete space character
        hrefs = [href.strip() for href in hrefs]
        # delete ununique players
        hrefs = np.unique(hrefs)
        return hrefs

# # get from internet
# _write_hrefs_in_file(_get_hrefs(_numberOfpages))
# hrefs = read_hrefs_from_file()
