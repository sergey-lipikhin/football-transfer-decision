using System;
using System.Collections.Generic;
using System.Text;

namespace TransferMarketApp.ViewModels.PagesVM.PlayerBoardVM.PlayerRatingTypes
{
    public class PlayerRatingItemBar : PlayerRatingItem
    {
        private string _margin;
        public string Margin
        {
            get { return _margin; }
            set
            {
                _margin = value;
                OnPropertyChanged(nameof(Margin));
            }
        }

        public PlayerRatingItemBar(double rating, int index)
        {
            Value = ConvertRating(rating);
            Name = RatingInfo[index].Item1;
            Description = RatingInfo[index].Item2;

            Margin = separatedItemsIndexies.Contains(index) ? "0,35,0,0" : "0";
        }

        private int _value;
        private string _name;
        private string _description;
        public override int Value
        {
            get { return _value; }
            set
            {
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
        public override void Reset() => Value = 0;

        private static List<int> separatedItemsIndexies = new List<int>()
        {
            4,9,14,19,24,30
        };
    }
}
