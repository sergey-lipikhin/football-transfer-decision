using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TransferMarketApp.ViewModels.Validation;

namespace TransferMarketApp.ViewModels.PagesVM.PlayerBoardVM
{
    public class PlayerPersonalTab : ViewModelBase
    {
        public PlayerPersonalTab()
        {
            ClubsNames = Service.ApplicationUserManager.getInstance().ClubsNames;
        }

        public List<string> ClubsNames { get; }

        #region controls enability
        public bool IsReadOnly =>
            !Service.ApplicationUserManager.getInstance().IsAdmin;
        public bool IsEnable =>
            Service.ApplicationUserManager.getInstance().IsAdmin;
        #endregion

        private string _name;
        private int _age;
        private string _nationality;

        [PlayerNameValidation]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                UpdateResultText = "";
                OnPropertyChanged(nameof(Name));
            }
        }
        [PlayerNationalityValidation]
        public string Nationality
        {
            get { return _nationality; }
            set
            {
                _nationality = value;
                UpdateResultText = "";
                OnPropertyChanged(nameof(Nationality));
            }
        }
        [PlayerAgeValidation]
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                UpdateResultText = "";
                OnPropertyChanged(nameof(Age));
            }
        }
        // Club presentation in View is special. So there is no DataAnnotations.
        private bool ClubValidate => ClubsNames.Any(club => club == _club);

        private string _club;
        public string Club
        {
            get { return _club; }
            set
            {
                _club = value;
                if (!ClubValidate) ClubErrorText = "Such club does not exist";
                else ClubErrorText = "";
                UpdateResultText = "";
                OnPropertyChanged(nameof(Club));
            }
        }
        private string _club_error_text;
        public string ClubErrorText
        {
            get { return _club_error_text; }
            set
            {
                _club_error_text = value;
                OnPropertyChanged(nameof(ClubErrorText));
            }
        }
        private string _update_result_text;
        public string UpdateResultText
        {
            get { return _update_result_text; }
            set
            {
                _update_result_text = value;
                OnPropertyChanged(nameof(UpdateResultText));
            }
        }
        // Button Commands
        public RelayCommand SavePlayerCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (selectedPlayerItem != null)
                    {
                        SetOriginFromTab();
                    }
                });
            }
        }
        public RelayCommand CancelPlayerCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (selectedPlayerItem != null)
                    {
                        SetTabFromOrigin();
                    }
                });
            }
        }

        public PlayerItem selectedPlayerItem { private set; get; }

        // update PlayerPersonalTab by new player
        public void Update(PlayerItem playerItem)
        {
            selectedPlayerItem = playerItem;
            SetTabFromOrigin();
        }
        private void SetTabFromOrigin()
        {
            Name = selectedPlayerItem.Name;
            Age = selectedPlayerItem.Age;
            Nationality = selectedPlayerItem.Nationality;
            Club = selectedPlayerItem.Club;
            SetPlayerPosition(selectedPlayerItem.Position);
            SetPlayerStatus(selectedPlayerItem.PlayerStatus);
        }
        private void SetOriginFromTab()
        {
            if (!AllValidations(this))
            {
                UpdateResultText = "Update failure";
                return;
            }

            try
            {
                if (Service.ApplicationUserManager.getInstance().
                    UpdatePlayer(selectedPlayerItem.Id, Name, Age, Nationality, Club, Position, PlayerStatus))
                {
                    selectedPlayerItem.Name = Name;
                    selectedPlayerItem.Age = Age;
                    selectedPlayerItem.Nationality = Nationality;
                    selectedPlayerItem.Club = Club;
                    selectedPlayerItem.Position = Position;
                    selectedPlayerItem.PlayerStatus = PlayerStatus;

                    UpdateResultText = "Updated correctly";
                    return;
                }
                UpdateResultText = "Update failure";
            }
            catch
            {
                UpdateResultText = "Server failure";
                return;
            }
        }

        // check if all parameters is correct
        private static bool AllValidations(PlayerPersonalTab infoTabVM)
        {
            return Validator.TryValidateObject(infoTabVM, new ValidationContext(infoTabVM),
                new List<ValidationResult>(), true) && infoTabVM.ClubValidate;
        }

        #region Player status picker
        public string PlayerStatus => IsOnTransfer ? "On transfer" : IsActive ? "Active" : IsBlocked ? "Blocked" : "Retired";
        private void SetPlayerStatus(string playerStatus)
        {
            switch (playerStatus)
            {
                case "On transfer": { IsOnTransfer = true; break; }
                case "Active": { IsActive = true; break; }
                case "Blocked": { IsBlocked = true; break; }
                default: { IsRetired = true; break; }
            }
        }

        private bool _is_on_transfer;
        private bool _is_active;
        private bool _is_blocked;
        private bool _is_retired;
        public bool IsOnTransfer
        {
            get { return _is_on_transfer; }
            set
            {
                _is_on_transfer = value;
                OnPropertyChanged(nameof(IsOnTransfer));
                OnPropertyChanged(nameof(PlayerStatus));
            }
        }
        public bool IsActive
        {
            get { return _is_active; }
            set
            {
                _is_active = value;
                OnPropertyChanged(nameof(IsActive));
                OnPropertyChanged(nameof(PlayerStatus));
            }
        }
        public bool IsBlocked
        {
            get { return _is_blocked; }
            set
            {
                _is_blocked = value;
                OnPropertyChanged(nameof(IsBlocked));
                OnPropertyChanged(nameof(PlayerStatus));
            }
        }
        public bool IsRetired
        {
            get { return _is_retired; }
            set
            {
                _is_retired = value;
                OnPropertyChanged(nameof(IsRetired));
                OnPropertyChanged(nameof(PlayerStatus));
            }
        }
        #endregion


        #region Player position picker
        public string Position => IsGk ? "GK" : IsDef ? "DF" : IsMdf ? "MF" : "FW";
        private void SetPlayerPosition(string position)
        {
            switch (position)
            {
                case "GK": { IsGk = true; break; }
                case "DF": { IsDef = true; break; }
                case "MF": { IsMdf = true; break; }
                default: { IsFw = true; break; }
            }
        }

        private bool _is_gk;
        private bool _is_def;
        private bool _is_mdf;
        private bool _is_fw;
        public bool IsGk
        {
            get { return _is_gk; }
            set
            {
                _is_gk = value;
                OnPropertyChanged(nameof(IsGk));
                OnPropertyChanged(nameof(Position));
            }
        }
        public bool IsDef
        {
            get { return _is_def; }
            set
            {
                _is_def = value;
                OnPropertyChanged(nameof(IsDef));
                OnPropertyChanged(nameof(Position));
            }
        }
        public bool IsMdf
        {
            get { return _is_mdf; }
            set
            {
                _is_mdf = value;
                OnPropertyChanged(nameof(IsMdf));
                OnPropertyChanged(nameof(Position));
            }
        }
        public bool IsFw
        {
            get { return _is_fw; }
            set
            {
                _is_fw = value;
                OnPropertyChanged(nameof(IsFw));
                OnPropertyChanged(nameof(Position));
            }
        }
        #endregion
    }
}
