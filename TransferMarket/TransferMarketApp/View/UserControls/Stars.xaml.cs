using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TransferMarketApp.View.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Stars.xaml
    /// </summary>
    public partial class Stars : UserControl
    {
        public object RatingAttribute
        {
            get { return (object)GetValue(RatingAttributeProperty); }
            set { SetValue(RatingAttributeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RatingAttribute.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RatingAttributeProperty =
            DependencyProperty.Register("RatingAttribute", typeof(object), typeof(Stars), new PropertyMetadata(0));
        public Stars()
        {
            InitializeComponent();
        }
    }
}
