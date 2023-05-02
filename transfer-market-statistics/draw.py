import matplotlib.pyplot as plt
import matplotlib.ticker as mtick


class DrawGraphs:
    @staticmethod
    def plot_fees_by_club(data):
        plt.figure(figsize=(10, 4))
        plt.barh(list(data.keys()), list(data.values()), color='slateblue')
        plt.title('Клубні трансферні витрати', fontsize=24)
        plt.xlabel('Обсяг витрат, ' + chr(163), fontsize=19)
        plt.xticks(fontsize=12)
        plt.yticks(fontsize=12)
        plt.show()

    @staticmethod
    def plot_fees_by_club_multiple(data1, data2):
        fig, (ax1, ax2) = plt.subplots(2, sharex=True)
        fig.suptitle('Клубні трансферні витрати', fontsize=24)
        ax1.barh(list(data1.keys()), list(data1.values()), color='slateblue')
        ax2.barh(list(data2.keys()), list(data2.values()), color='deepskyblue')
        ax2.set_xlabel('Обсяг витрат, ' + chr(163), fontsize=10)
        ax1.set_title('English Premier League', fontsize=14, loc='left')
        ax2.set_title('La Liga', fontsize=14, loc='left')
        plt.show()

    @staticmethod
    def plot_fees_by_years(data):
        plt.figure(figsize=(10, 4))
        plt.bar(list(data.keys()), list(data.values()), color='slateblue')
        plt.title('Щорічні трансферні витрати', fontsize=24)
        plt.xlabel('Сезон', fontsize=19)
        plt.ylabel('Обсяг витрат, ' + chr(163), fontsize=19)
        plt.xticks(list(data.keys())[1::5], fontsize=12)
        plt.yticks(fontsize=12)
        plt.show()

    @staticmethod
    def plot_fees_and_numbers_by_years(data_fees, numbers):

        fig, ax1 = plt.subplots()

        ax1.set_xlabel('Сезон', fontsize=19)
        ax1.set_ylabel('Кількість трансферів', fontsize=19)
        plt.bar(list(numbers.keys()), list(numbers.values()), color='deepskyblue')
        plt.xticks(list(numbers.keys())[1::5], fontsize=12)
        plt.yticks(fontsize=12)

        ax2 = ax1.twinx()  # instantiate a second axes that shares the same x-axis

        color = 'tab:red'
        ax2.set_ylabel('Обсяг витрат, ' + chr(163), fontsize=19, color=color)  # we already handled the x-label with ax1
        plt.plot(list(data_fees.keys()), list(data_fees.values()), color=color)
        ax2.tick_params(axis='y', labelcolor=color)

        fig.tight_layout()  # otherwise the right y-label is slightly clipped
        plt.show()

    @staticmethod
    def plot_transfer_expenditure_to_revenue_ratio():
        season = ('2013/2014', '2014/2015', '2015/2016', '2016/2017', '2017/2018',)
        revenue = (11303, 12056, 13416, 14664, 15590)
        expenditure = (2667, 2815, 3652, 4105, 5652)
        ratio = [round(expenditure[i]/revenue[i]*100, 2) for i in range(5)]

        fig, ax1 = plt.subplots()

        ax1.set_xlabel('Сезон', fontsize=19)
        ax1.set_ylabel('Співвідношення доходів до трансферних затрат', fontsize=19)
        plt.plot(season, ratio, color='deepskyblue')
        for index in range(len(ratio)):
            ax1.text(season[index], ratio[index], ratio[index], size=12, verticalalignment='top')
        plt.yticks([10, 20, 30, 40, 50], fontsize=12)
        ax1.yaxis.set_major_formatter(mtick.PercentFormatter())

        ax2 = ax1.twinx()  # instantiate a second axes that shares the same x-axis

        color = 'tab:red'
        ax2.set_ylabel('Доходи та Витрати\n(m, ' + chr(8364) + ')', fontsize=19,
                       color=color)  # we already handled the x-label with ax1
        plt.plot(season, expenditure, color=color)
        for index in range(len(ratio)):
            ax2.text(season[index], expenditure[index], expenditure[index], size=12, verticalalignment='top')
        plt.yticks([0, 5000, 10000, 15000, 20000, 25000], fontsize=12)
        ax2.tick_params(axis='y', labelcolor=color)

        plt.plot(season, revenue, color='gray')
        for index in range(len(ratio)):
            plt.text(season[index], revenue[index], revenue[index], size=12, verticalalignment='top')

        fig.legend(['Співвідношення', 'Витрати', 'Доходи'], loc='lower center')

        fig.tight_layout()  # otherwise the right y-label is slightly clipped
        plt.show()

    @staticmethod
    def plot_transfer_max_and_mean(data_fees, numbers, max_fees):

        mean_fees = [data_fees[el] / numbers[el] for el in data_fees.keys()]

        fig, ax1 = plt.subplots()

        ax1.set_xlabel('Сезон', fontsize=19)
        ax1.set_ylabel('Трансферні затрати\n(m, ' + chr(163) + ')', fontsize=19)
        ax1.bar(list(data_fees.keys()), list(max_fees.values()), color='deepskyblue')
        plt.yticks([0, 50, 100, 150, 200], fontsize=12)

        ax2 = ax1.twinx()  # instantiate a second axes that shares the same x-axis

        color = 'tab:red'
        ax2.set_ylabel('Трансферні затрати\n(m, ' + chr(163) + ')', fontsize=19,
                       color=color)  # we already handled the x-label with ax1
        plt.plot(list(data_fees.keys()), mean_fees, color=color)
        plt.yticks([0, 2, 4, 6, 8], fontsize=12)
        ax2.tick_params(axis='y', labelcolor=color)

        plt.xticks(list(data_fees.keys())[1::5], fontsize=12)

        fig.legend(['Максимальне значення','Середнє значення'], loc='lower center')

        fig.tight_layout()  # otherwise the right y-label is slightly clipped
        plt.show()
