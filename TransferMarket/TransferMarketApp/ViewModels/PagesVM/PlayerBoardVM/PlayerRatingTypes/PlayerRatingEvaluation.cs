using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TransferMarketApp.ViewModels.PagesVM.PlayerBoardVM.PlayerRatingTypes
{
    public class PlayerRatingEvaluation : ViewModelBase
    {
        public PlayerRatingEvaluation()
        {
            PredictButtonAnimation = new Animations.ButtonRotateAnimation();
        }

        // Button animation
        public Animations.ButtonRotateAnimation PredictButtonAnimation { private set; get; }

        public async void GetPrediction(List<double> features)
        {
            PredictButtonAnimation.AnimationStart();

            double answer = 0.0;
            await Task.Factory.StartNew(() =>
            {
                answer = Service.ApplicationUserManager.getInstance().Predict(features);
            });

            MarketValue = answer;
            EvaluationDate = DateTime.Now;

            PredictButtonAnimation.AnimationStop();
        }


        private double _market_value;
        public double MarketValue
        {
            get { return _market_value; }
            set
            {
                _market_value = value;
                OnPropertyChanged(nameof(MarketValue));
                OnPropertyChanged(nameof(MarketValueString));
            }
        }

        private DateTime _evaluation_date;
        public DateTime EvaluationDate
        {
            get { return _evaluation_date; }
            private set
            {
                _evaluation_date = value;
                OnPropertyChanged(nameof(EvaluationDate));
                OnPropertyChanged(nameof(EvaluationDateString));
            }
        }

        public string MarketValueString => string.Format("{0} \u00A3", MarketValue);
        public string EvaluationDateString => EvaluationDate == DateTime.MinValue ? "" :
            "Evaluated for " + EvaluationDate.ToString("d");
    }
}
