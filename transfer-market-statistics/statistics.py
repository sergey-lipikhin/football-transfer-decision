import csv
from leagues import Leagues


class GetStatistics:
    @staticmethod
    def get_fees_by_club(league):
        d = dict()
        for x in range(1992, 2020):
            with open('./data/' + str(x) + '/' + league.value + '.csv',
                      errors='ignore') as file:
                csvreader = csv.reader(file)
                for row in csvreader:
                    ParseDataRow.full_transfer_volume(row, d, 0)
        return d

    @staticmethod
    def get_fees_by_years():
        d = dict()
        for year in range(1992, 2020):
            for league in [el.value for el in Leagues]:
                with open('./data/' + str(year) + '/' + league + '.csv',
                          errors='ignore') as file:
                    csvreader = csv.reader(file)
                    for row in csvreader:
                        ParseDataRow.in_transfer_volume(row, d, len(row) - 1)
        return d

    @staticmethod
    def get_number_of_transfers():
        d = dict()
        for year in range(1992, 2020):
            for league in [el.value for el in Leagues]:
                with open('./data/' + str(year) + '/' + league + '.csv',
                          errors='ignore') as file:
                    csvreader = csv.reader(file)
                    for row in csvreader:
                        ParseDataRow.number_of_transfers(row, d, len(row) - 1)
        return d

    @staticmethod
    def get_max_transfer_fee():
        d = dict()
        for year in range(1992, 2020):
            for league in [el.value for el in Leagues]:
                with open('./data/' + str(year) + '/' + league + '.csv',
                          errors='ignore') as file:
                    csvreader = csv.reader(file)
                    for row in csvreader:
                        ParseDataRow.max_transfer_fee(row, d, len(row) - 1)
        return d


class ParseDataRow:
    @staticmethod
    def full_transfer_volume(row, dictionary, key_number):
        if row[5][:2] == 'ВЈ':
            key = row[key_number]
            element = 0
            if row[5][-1] == '.':
                element = float(row[5].split('Ј')[1].split('T')[0]) / 1000
            elif row[5][-1] == 'm':
                element = float(row[5].split('Ј')[1].split('m')[0])
            if row[6] == 'in':
                if key in dictionary:
                    dictionary[key] = dictionary[key] + element
                else:
                    dictionary[key] = element
            elif row[6] == 'out':
                if key in dictionary:
                    dictionary[key] = dictionary[key] - element
                else:
                    dictionary[key] = -1 * element

    @staticmethod
    def in_transfer_volume(row, dictionary, key_number):
        if row[5][:2] == 'ВЈ':
            key = row[key_number]
            element = 0
            if row[5][-1] == '.':
                element = float(row[5].split('Ј')[1].split('T')[0]) / 1000
            elif row[5][-1] == 'm':
                element = float(row[5].split('Ј')[1].split('m')[0])
            if row[6] == 'in':
                if key in dictionary:
                    dictionary[key] = dictionary[key] + element
                else:
                    dictionary[key] = element

    @staticmethod
    def out_transfer_volume(row, dictionary, key_number):
        if row[5][:2] == 'ВЈ':
            key = row[key_number]
            element = 0
            if row[5][-1] == '.':
                element = float(row[5].split('Ј')[1].split('T')[0]) / 1000
            elif row[5][-1] == 'm':
                element = float(row[5].split('Ј')[1].split('m')[0])
            if row[6] == 'out':
                if key in dictionary:
                    dictionary[key] = dictionary[key] + element
                else:
                    dictionary[key] = element

    @staticmethod
    def number_of_transfers(row, dictionary, key_number):
        if row[5][:2] == 'ВЈ':
            key = row[key_number]
            if row[6] == 'in':
                if key in dictionary:
                    dictionary[key] = dictionary[key] + 1
                else:
                    dictionary[key] = 1

    @staticmethod
    def max_transfer_fee(row, dictionary, key_number):
        if row[5][:2] == 'ВЈ':
            key = row[key_number]
            element = 0
            if row[5][-1] == '.':
                element = float(row[5].split('Ј')[1].split('T')[0]) / 1000
            elif row[5][-1] == 'm':
                element = float(row[5].split('Ј')[1].split('m')[0])
            if row[6] == 'in':
                if key in dictionary:
                    if dictionary[key] < element:
                        dictionary[key] = element
                else:
                    dictionary[key] = element
