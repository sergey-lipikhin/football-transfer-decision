using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace TransferMarketApp.ViewModels.Converters
{
    /// <summary>
    /// Convert the TabItemContent to Margin value
    /// </summary>
    public class ContentToMarginConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new Thickness(0, 0, -((ContentPresenter)value).ActualHeight, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
