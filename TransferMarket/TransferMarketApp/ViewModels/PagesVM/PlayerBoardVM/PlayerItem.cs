using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace TransferMarketApp.ViewModels.PagesVM.PlayerBoardVM
{
    public class PlayerItem : ViewModelBase
    {
        public PlayerItem(Model.Player player)
        {
            _id = player.Id;
            _name = player.Name;
            Age = player.Age;
            Nationality = player.Nationality;
            Club = player.Club;
            Position = player.Position;
            PlayerStatus = player.PlayerStatus;
        }
        public int Id 
        {
            get { return _id; }
            private set
            {
                _id = value;
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;              
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(AgeLabel));
            }
        }
        public string Nationality
        {
            get { return _nationality; }
            set
            {
                _nationality = value;
                OnPropertyChanged(nameof(Nationality));
                OnPropertyChanged(nameof(NationalityImage));
            }
        }
        public string Club
        {
            get { return _club; }
            set
            {
                _club = value;
                OnPropertyChanged(nameof(Club));
            }
        }
        public string Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged(nameof(Position));
            }
        }
        public string PlayerStatus
        {
            get { return _player_status; }
            set
            {
                _player_status = value;
                OnPropertyChanged(nameof(PlayerStatus));
                UpdatePlayerStatusColor();
            }
        }

        private int _id;
        private string _name;
        private int _age;
        private string _nationality;
        private string _club;
        private string _position;
        private string _player_status;

        #region View formats
        public string NationalityImage => Service.ApplicationUserManager.getInstance().
                nationalityConverter.GetImage(Nationality);
        public string AgeLabel => Age.ToString() + " y.o.";
        public SolidColorBrush PlayerStatusColor { set; get; }

        public void UpdatePlayerStatusColor()
        {
            PlayerStatusColor ??= new SolidColorBrush();
            switch (PlayerStatus)
            {
                case "Blocked": { PlayerStatusColor.Color = Color.FromRgb(255, 0, 0); break; }
                case "Active": { PlayerStatusColor.Color = Color.FromRgb(255, 153, 51); break; }
                case "On transfer": { PlayerStatusColor.Color = Color.FromRgb(0, 255, 0); break; }
                case "Retired": { PlayerStatusColor.Color = Color.FromRgb(96, 96, 96); break; }
                default: { PlayerStatusColor.Color = Color.FromRgb(96, 96, 96); break; }
            }
            OnPropertyChanged(nameof(PlayerStatusColor));
        }

        private Visibility _player_item_visibility;
        public Visibility PlayerItemVisibility
        {
            get { return _player_item_visibility; }
            set
            {
                _player_item_visibility = value;
                OnPropertyChanged(nameof(PlayerItemVisibility));
            }
        }

        #endregion
    }
}
