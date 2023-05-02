using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.ComponentModel.DataAnnotations;
using TransferMarketApp.ViewModels.Validation;

namespace TransferMarketApp.ViewModels.WindowsVM
{
    public class UserWindowVM : ViewModelBase
    { 
        public UserWindowVM() { Login = ""; Password = ""; }

        private string _login;
        private string _password;

        [UserLoginValidation]
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        [UserPasswordValidation]
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public RelayCommand ExitCommand => new RelayCommand(obj => { Application.Current.Shutdown(); });
        public RelayCommand ApplyCommand => new RelayCommand(obj =>
        {
            if (Validator.TryValidateObject(this, new ValidationContext(this),
                new List<ValidationResult>(), true))
            {
                MessageBox.Show("Yes");
            }
            MessageBox.Show("No");
        });
    }
}
