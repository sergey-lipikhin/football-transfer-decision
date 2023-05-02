using System;
using System.Collections.Generic;
using System.Text;

namespace TransferMarketApp.ViewModels.PagesVM.PlayerBoardVM.PlayerRatingTypes
{
    public class PlayerRatingItemStar : PlayerRatingItem
    {
        public PlayerRatingItemStar(double rating, int index)
        {
            Value = ConvertRating(rating);
            Name = RatingInfo[index].Item1;
            Description = RatingInfo[index].Item2;
        }

        private static string Unselected = "/View/Images/star_96px.png";
        private static string Selected = "/View/Images/star_filled_96px.png";

        private int _value;
        private string _name;
        private string _description;
        public override int Value
        {
            get { return _value; }
            set
            {
                UpdateStars(value);
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
        public override string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public override string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public override void Reset() => Value = 1;


        private string _first_star;
        private string _second_star;
        private string _thirtd_star;
        private string _fourth_star;
        private string _fifth_star;
        public string FirstStar
        {
            get { return _first_star; }
            set
            {
                _first_star = value;
                OnPropertyChanged(nameof(FirstStar));
            }
        }
        public string SecondStar
        {
            get { return _second_star; }
            set
            {
                _second_star = value;
                OnPropertyChanged(nameof(SecondStar));
            }
        }
        public string ThirdStar
        {
            get { return _thirtd_star; }
            set
            {
                _thirtd_star = value;
                OnPropertyChanged(nameof(ThirdStar));
            }
        }
        public string FourthStar
        {
            get { return _fourth_star; }
            set
            {
                _fourth_star = value;
                OnPropertyChanged(nameof(FourthStar));
            }
        }
        public string FifthStar
        {
            get { return _fifth_star; }
            set
            {
                _fifth_star = value;
                OnPropertyChanged(nameof(FifthStar));
            }
        }

        public RelayCommand StarClickCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Value = int.TryParse(obj.ToString(), out int result) ? result : 1;
                });
            }
        }
        private void UpdateStars(int value)
        {
            switch (value)
            {
                case 1: { FirstStar = Selected; SecondStar = Unselected; ThirdStar = Unselected; FourthStar = Unselected; FifthStar = Unselected; break; }
                case 2: { FirstStar = Selected; SecondStar = Selected; ThirdStar = Unselected; FourthStar = Unselected; FifthStar = Unselected; break; }
                case 3: { FirstStar = Selected; SecondStar = Selected; ThirdStar = Selected; FourthStar = Unselected; FifthStar = Unselected; break; }
                case 4: { FirstStar = Selected; SecondStar = Selected; ThirdStar = Selected; FourthStar = Selected; FifthStar = Unselected; break; }
                case 5: { FirstStar = Selected; SecondStar = Selected; ThirdStar = Selected; FourthStar = Selected; FifthStar = Selected; break; }
                default: break;
            }
        }
    }
}
