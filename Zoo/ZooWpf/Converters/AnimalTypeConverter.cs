using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using ZooWpf.ZooModels;

namespace ZooWpf.Converters
{
    [ValueConversion(typeof(Object), typeof(string))]
    public class AnimalTypeConverter : IValueConverter
    {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is Object obj)
                {
                    return  obj is Dog ? "ceci est un chien" : "ceci est un chat";
                }
                return "ceci est un animal";
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    }
}
