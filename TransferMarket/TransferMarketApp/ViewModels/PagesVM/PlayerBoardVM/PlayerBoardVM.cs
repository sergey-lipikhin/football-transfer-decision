using System;
using System.Collections.ObjectModel;
using System.Windows;
using TransferMarketApp.ViewModels.PagesVM.PlayerBoardVM.PlayerRatingTypes;
using TransferMarketApp.Service;
using System.Linq;
using System.Threading.Tasks;

namespace TransferMarketApp.ViewModels.PagesVM.PlayerBoardVM
{
    public class PlayerBoardVM : ViewModelBase
    {
        public PlayerPersonalTab PlayerPersonalTab { get; set; }
        public PlayerRatingTab PlayerRatingTab { get; set; }

        public ObservableCollection<PlayerItem> Players { get; set; }

        private PlayerItem _selected_player_item;
        public PlayerItem SelectedPlayerItem
        {
            get { return _selected_player_item; }
            set
            {
                _selected_player_item = value;
                PlayerPersonalTab.Update(_selected_player_item);

                PlayerRatingTab.SetPlayerRatingTab(ApplicationUserManager.getInstance().ReadRating(ApplicationUserManager.getInstance().User.Id, _selected_player_item.Id),
                    _selected_player_item.Id);

                OnPropertyChanged(nameof(SelectedPlayerItem));
            }
        }

        public PlayerBoardVM()
        {
            PlayerPersonalTab = new PlayerPersonalTab();
            PlayerRatingTab = new PlayerRatingTab();

            Players = new ObservableCollection<PlayerItem>();

            ApplicationUserManager.getInstance().Players.ForEach(player => Players.Add(new PlayerItem(player)));

            _search_player = "";
            _search_club = "";
            UpdateButtonAnimation = new Animations.ButtonRotateAnimation();
        }

        public string UserLabel => string.Format("{0}", ApplicationUserManager.getInstance().IsAdmin ? "Admin" : "User");
        public string LoginLabel => string.Format("Logged in as: {0}", ApplicationUserManager.getInstance().User.Login);
        public Animations.ButtonRotateAnimation UpdateButtonAnimation { private set; get; }

        private bool _sort_by_nation;
        private bool _sort_by_position;
        private bool _sort_by_name;
        private bool _sort_by_age;
        private bool _sort_by_status;

        public bool SortByNation
        {
            get { return _sort_by_nation; }
            set
            {
                _sort_by_nation = value;
                if (value) SortPlayers(value => value.Nationality);
                OnPropertyChanged(nameof(SortByNation));
            }
        }
        public bool SortByPosition
        {
            get { return _sort_by_position; }
            set
            {
                _sort_by_position = value;
                if (value) SortPlayers(value => value.Position);
                OnPropertyChanged(nameof(SortByPosition));
            }
        }
        public bool SortByName
        {
            get { return _sort_by_name; }
            set
            {
                _sort_by_name = value;
                if (value) SortPlayers(value => value.Name);
                OnPropertyChanged(nameof(SortByName));
            }
        }
        public bool SortByAge
        {
            get { return _sort_by_age; }
            set
            {
                _sort_by_age = value;
                if (value) SortPlayers(value => value.Age.ToString());
                OnPropertyChanged(nameof(SortByAge));
            }
        }
        public bool SortByStatus
        {
            get { return _sort_by_status; }
            set
            {
                _sort_by_status = value;
                if (value) SortPlayers(value => value.PlayerStatus);
                OnPropertyChanged(nameof(SortByStatus));
            }
        }

        private string _search_player;
        public string SearchPlayer
        {
            get { return _search_player; }
            set
            {
                _search_player = value;
                UpdatePlayers();
                OnPropertyChanged(nameof(SearchPlayer));
            }
        }
        private string _search_club;
        public string SearchClub
        {
            get { return _search_club; }
            set
            {
                _search_club = value;
                UpdatePlayers();
                OnPropertyChanged(nameof(SearchClub));
            }
        }
        private async void UpdatePlayers()
        {
            await Task.Run(() =>
            {
                Players.ToList().ForEach(player =>
                {
                    if (player.Name.ToUpper().Contains(SearchPlayer.ToUpper()) && player.Club.ToUpper().Contains(SearchClub.ToUpper()))
                    {
                        player.PlayerItemVisibility = Visibility.Visible;
                    }
                    else
                    {
                        player.PlayerItemVisibility = Visibility.Collapsed;
                    }
                });
            });
        }

        private void SortPlayers(Func<PlayerItem, string> selector)
        {
            ObservableCollection<PlayerItem> tempPlayers = new ObservableCollection<PlayerItem>(Players);
            Players.Clear();
            tempPlayers.OrderBy(selector).ToList().ForEach(Players.Add);
        }

        public RelayCommand UpdateCommand => new RelayCommand(obj =>
        {
            UpdateButtonAnimation.AnimationSeconds(500);

            Players.Clear();

            SearchClub = "";
            SearchPlayer = "";

            SortByNation = false;
            SortByPosition = false;
            SortByName = false;
            SortByAge = false;
            SortByStatus = false;

            ApplicationUserManager.getInstance().UpdatePlayers();
            ApplicationUserManager.getInstance().Players.ForEach(player => Players.Add(new PlayerItem(player)));
        });
    }
}
