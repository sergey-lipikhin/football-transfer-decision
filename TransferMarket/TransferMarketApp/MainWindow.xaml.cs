using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TransferMarketApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ViewModels.WindowsVM.MainWindowVM();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // normalize window before position changing if it was maximized
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;

                Left = Mouse.GetPosition(this).X - Width / 2;
                Top = 0;

                if (Left < 0) Left = 0;
                else
                {
                    if (Left + Width > SystemParameters.PrimaryScreenWidth) Left = SystemParameters.PrimaryScreenWidth - Width;
                } 
            }

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
