using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Service.Global.Converters
{
    public class BooleanToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (bool) value
            ? Brushes.YellowGreen
            : Brushes.Red;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}