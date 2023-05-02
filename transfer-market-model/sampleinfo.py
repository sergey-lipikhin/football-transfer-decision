NUM_TOTAL = 15233
NUM_FEATURES = 34
NUM_100SCALEFEATURES = 31
NUM_5SCALEFEATURES = 3


NUM_TEST = 2500
NUM_TRAIN = NUM_TOTAL - NUM_TEST  # 12840

_header_22 = 'Name,Club,Position,Weak Foot,Skill Moves,International Reputation,Price,'\
    'Overall,Potential,Crossing,Finishing,Heading Accuracy,Short Passing,'\
        'Volleys,Dribbling,Curve,Free Kick Accuracy,Long Passing,Ball Control,'\
            'Acceleration,Sprint Speed,Agility,Reactions,Balance,'\
                'Shot Power,Jumping,Stamina,Strength,Long Shots,'\
                    'Aggression,Interceptions,Positioning,Vision,Penalties,Composure,'\
                        'Defensive Awareness,Standing Tackle,Sliding Tackle'
_header_22_ukr = 'Ім''я,Клуб,Позиція,Слабка нога,Майстерність,Міжнародна репутація,Ціна,'\
    'Загальний рейтинг,Потенціал,Кроси,Завершення,Гра головою,Короткі паси,Удар з льоту,'\
        'Дриблінг,Підкручення м’яча,Штрафні удари,Дальні паси,Контроль м’яча,Прискорення,Спринт,'\
            'Спритність,Реакція,Баланс,Потужність удару,Стрибки,Витривалість,Сила,Дальні постріли,'\
                'Агресія,Перехоплення,Позиціонування,Бачення поля,Пенальті,Самовладання,Гра по супернику,Відбір,Підкат'
                        
HEADER_22 = _header_22.split(',')
HEADER_22_UKR = _header_22_ukr.split(',')

FEATURES_AND_PRICE = HEADER_22[3:6] + HEADER_22[7:] + [HEADER_22[6]]
FEATURES_AND_PRICE_UKR = HEADER_22_UKR[3:6] + HEADER_22_UKR[7:] + [HEADER_22_UKR[6]]
# -Overall +Defending
FEATURES_AND_PRICE_Defending = HEADER_22[3:6] + HEADER_22[8:-3] + ['Defending'] + [HEADER_22[6]]
