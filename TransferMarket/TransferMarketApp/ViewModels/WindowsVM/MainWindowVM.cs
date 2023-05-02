using System.Windows;
using System.Windows.Controls;

namespace TransferMarketApp.ViewModels.WindowsVM
{
    public class MainWindowVM : ViewModelBase
    {
        public MainWindowVM()
        {
            OpenMenu();
            InitPages();
            CloseMenu();

            CurrentPage = PlayerBoardPage;
        }

        private Visibility _visibility_menu;
        private int _column_frame;
        private int _column_frame_span;

        public Visibility VisibilityMenu
        {
            get { return _visibility_menu; }
            set
            {
                _visibility_menu = value;
                OnPropertyChanged(nameof(VisibilityMenu));
            }
        }
        public int ColumnFrame
        {
            get { return _column_frame; }
            set
            {
                _column_frame = value;
                OnPropertyChanged(nameof(ColumnFrame));
            }
        }
        public int ColumnFrameSpan
        {
            get { return _column_frame_span; }
            set
            {
                _column_frame_span = value;
                OnPropertyChanged(nameof(ColumnFrameSpan));
            }
        }
        public View.Pages.PlayerBoardPage PlayerBoardPage { set; get; }

        private Page _current_page;
        public Page CurrentPage
        {
            get { return _current_page; }
            set
            {
                _current_page = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        public RelayCommand ExitCommand
        {
            get { return new RelayCommand(obj => { Application.Current.Shutdown(); }); }
        }
        public RelayCommand MaximizeCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Window this_window = (Window)obj;
                    this_window.WindowState = this_window.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
                });
            }
        }
        public RelayCommand MinimizeCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Window this_window = (Window)obj;
                    this_window.WindowState = WindowState.Minimized;
                });
            }
        }
        public RelayCommand OpenCloseMenuCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (VisibilityMenu == Visibility.Visible) CloseMenu();
                    else OpenMenu();
                });
            }
        }
        public RelayCommand OpenPlayerBoardPagePageCommand
        {
            get { return new RelayCommand(obj => { CurrentPage = PlayerBoardPage; }); }
        }

        private void OpenMenu()
        {
            VisibilityMenu = Visibility.Visible;
            ColumnFrame = 1;
            ColumnFrameSpan = 0;
        }
        private void CloseMenu()
        {
            VisibilityMenu = Visibility.Hidden;
            ColumnFrame = 0;
            ColumnFrameSpan = 2;
        }
        private void InitPages()
        {
            PlayerBoardPage = new View.Pages.PlayerBoardPage();
        }
    }
}
