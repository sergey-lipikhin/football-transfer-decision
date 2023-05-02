using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TransferMarketApp.ViewModels
{
    public class ViewModelBase : PropertyValidateViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
