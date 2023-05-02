using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;

namespace TransferMarketApp.ViewModels.PagesVM.PlayerBoardVM.PlayerRatingTypes
{
    public class PlayerRatingTab : ViewModelBase
    {
        private int _player_id;

        public PlayerRatingEvaluation PlayerRatingEvaluation { set; get; }

        public PlayerRatingItemStar InternationalReputation { set; get; }
        public PlayerRatingItemStar SkillMoves { set; get; }
        public PlayerRatingItemStar WeakFoot { set; get; }

        public ObservableCollection<PlayerRatingItemBar> playerRatingList { set; get; }

        public void SetPlayerRatingTab(List<double> player_rating_list, int playerId)
        {
            if (player_rating_list.Count != PlayerRatingItem.FEATURES_END) return;

            SaveResultText = "";

            _player_id = playerId;

            PlayerRatingEvaluation = new PlayerRatingEvaluation();
            PlayerRatingEvaluation.MarketValue = player_rating_list[PlayerRatingItem.PRICE];

            playerRatingList = new ObservableCollection<PlayerRatingItemBar>();
            for (int index = PlayerRatingItem.FEATURES_START; index < PlayerRatingItem.FEATURES_END; index++)
            {
                playerRatingList.Add(new PlayerRatingItemBar(player_rating_list[index], index));
            }

            InternationalReputation = new PlayerRatingItemStar(player_rating_list[PlayerRatingItem.INTERNATIONAL_REPUTATION], PlayerRatingItem.INTERNATIONAL_REPUTATION);
            SkillMoves = new PlayerRatingItemStar(player_rating_list[PlayerRatingItem.SKILL_MOVES], PlayerRatingItem.SKILL_MOVES);
            WeakFoot = new PlayerRatingItemStar(player_rating_list[PlayerRatingItem.WEAK_FOOT], PlayerRatingItem.WEAK_FOOT);
        }

        public RelayCommand SaveCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (isNull) return;

                    if (Service.ApplicationUserManager.getInstance().UpdateInsertRating(Service.ApplicationUserManager.getInstance().User.Id,
                        _player_id, GetRatingList()))
                        SaveResultFade("Updated correctly");
                    else SaveResultFade("Update failure");
                });
            }
        }
        public RelayCommand ResetCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (isNull) return;
                    InternationalReputation.Reset(); SkillMoves.Reset(); WeakFoot.Reset();
                    playerRatingList.ToList().ForEach(el => el.Reset());
                });
            }
        }
        public RelayCommand PredictCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (isNull) return;
                    PlayerRatingEvaluation.GetPrediction(GetRatingList(isPrice:false));
                });
            }
        }

        private bool isNull => (PlayerRatingEvaluation == null) || (InternationalReputation == null)
                || WeakFoot == null || SkillMoves == null || playerRatingList == null;
        private List<double> GetRatingList(bool isPrice = true)
        {
            List<double> rating = new List<double>();

            if (isPrice) rating.Add(PlayerRatingEvaluation.MarketValue);

            rating.Add(InternationalReputation.Value);
            rating.Add(SkillMoves.Value);
            rating.Add(WeakFoot.Value);

            playerRatingList.ToList().ForEach(el => rating.Add(el.Value));

            return rating;
        }


        private string _save_result_text;
        public string SaveResultText
        {
            get { return _save_result_text; }
            set
            {
                _save_result_text = value;
                OnPropertyChanged(nameof(SaveResultText));
            }
        }
        private async void SaveResultFade(string saveResult)
        {
            SaveResultText = saveResult;
            await Task.Run(() =>
            {
                Thread.Sleep(3000); 
                if (SaveResultText != "") SaveResultText = "";
            });
        }
    }
}
