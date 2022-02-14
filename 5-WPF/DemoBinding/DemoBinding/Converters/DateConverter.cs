using System;
using System.Globalization;
using System.Windows.Data;

namespace DemoBinding.Converters
{
    [ValueConversion(typeof(DateTime), typeof(String))]
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DateTime date)
            {
                return date.Year.ToString(); 
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new NotImplementedException();
            return null; 
        }
    }
}
