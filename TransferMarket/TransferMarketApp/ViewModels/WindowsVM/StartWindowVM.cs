using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace TransferMarketApp.ViewModels.WindowsVM
{
    public class StartWindowVM : ViewModelBase
    {
        public RelayCommand ExitCommand => new RelayCommand(obj => { Application.Current.Shutdown(); });

        public RelayCommand AdminWindowCommand => new RelayCommand(obj =>
        {
            if (obj is StartWindow)
            {
                Service.ApplicationUserManager.getInstance().SetUser(new Model.Admin() { Id = 6, Login = "Poradugebegom", Password = "Neskaju" });
                MainWindow mw = new MainWindow();

                mw.Show();
                ((StartWindow)obj).Close();
            }
        });

        public RelayCommand UserWindowCommand => new RelayCommand(obj =>
        {
            Service.ApplicationUserManager.getInstance().SetUser(new Model.User() { Id = 5, Login = "Panteri", Password = "LuboMuazer" });
            MainWindow mw = new MainWindow();

            mw.Show();
            ((StartWindow)obj).Close();
        });
    }
}
