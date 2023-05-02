class Crutches:
    @staticmethod
    def rename_la_liga(dictionary):
        dictionary['Hercules CF'] = dictionary.pop('HГ©rcules CF')
        dictionary['UD Almeria'] = dictionary.pop('UD AlmerГ\xada')
        dictionary['Cadiz CF'] = dictionary.pop('CГЎdiz CF')
        dictionary['Gimnastic de Tarragona'] = dictionary.pop('GimnГ\xa0stic de Tarragona')
        dictionary['CP Merida'] = dictionary.pop('CP MГ©rida (diss.)')
        dictionary['Atletico Madrid'] = dictionary.pop('AtlГ©tico Madrid')
        dictionary['Atletico de Madrid'] = dictionary.pop('AtlГ©tico de Madrid')
        dictionary['Real Betis Balompie'] = dictionary.pop('Real Betis BalompiГ©')
        dictionary['UD Salamanca'] = dictionary.pop('UD Salamanca (liq.)')
        dictionary['Deportivo de La Coruna'] = dictionary.pop('Deportivo de La CoruГ±a')
