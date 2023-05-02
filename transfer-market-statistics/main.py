import crutches
import leagues
import statistics
from statistics import GetStatistics
from draw import DrawGraphs
from leagues import Leagues


def sort_data(data):
    return dict(sorted(data.items(), key=lambda item: item[1])[-20:])


def print_data(data):
    for k in data.keys():
        print('{0}: {1}'.format(k, data[k]))


# graph 1
# transfer_fees = GetStatistics.get_fees_by_years()
# number_of_transfers = GetStatistics.get_number_of_transfers()
# DrawGraphs.plot_fees_and_numbers_by_years(transfer_fees, number_of_transfers)


# graph 2
# transfer_fees = GetStatistics.get_fees_by_club(Leagues.EPL)
# transfer_fees = sort_data(transfer_fees)
#
# transfer_fees2 = GetStatistics.get_fees_by_club(Leagues.LA)
# crutches.Crutches.rename_la_liga(transfer_fees2)
# transfer_fees2 = sort_data(transfer_fees2)
#
# DrawGraphs.plot_fees_by_club_multiple(transfer_fees, transfer_fees2)

# graph 3
# DrawGraphs.plot_transfer_expenditure_to_revenue_ratio()


# graph 4
# transfer_fees = GetStatistics.get_fees_by_years()
# number_of_transfers = GetStatistics.get_number_of_transfers()
# max_transfer_fee = statistics.GetStatistics.get_max_transfer_fee()
#
# DrawGraphs.plot_transfer_max_and_mean(transfer_fees, number_of_transfers, max_transfer_fee)
