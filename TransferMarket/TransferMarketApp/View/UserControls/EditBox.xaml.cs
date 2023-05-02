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
    /// Логика взаимодействия для EditBox.xaml
    /// </summary>
    public partial class EditBox : UserControl
    {
        public object PropertyName
        {
            get { return (object)GetValue(PropertyNameProperty); }
            set { SetValue(PropertyNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PropertyName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PropertyNameProperty =
            DependencyProperty.Register("PropertyName", typeof(object), typeof(EditBox), new PropertyMetadata(0));


        public object MainText
        {
            get { return (object)GetValue(MainTextProperty); }
            set { SetValue(MainTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MainText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainTextProperty =
            DependencyProperty.Register("MainText", typeof(object), typeof(EditBox), new PropertyMetadata(0));
        public EditBox()
        {
            InitializeComponent();
        }
    }
}
