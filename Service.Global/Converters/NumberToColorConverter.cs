using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Service.Global.Converters
{
    public class NumberToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && (double) value >= 0
                ? Brushes.YellowGreen
                : Brushes.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}