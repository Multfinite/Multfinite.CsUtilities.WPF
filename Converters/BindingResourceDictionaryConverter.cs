using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Multfinite.Utilities.WPF.Converters
{
    public class BindingResourceDictionaryConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ResourceDictionary dictionary = (ResourceDictionary) values[1];
            if (values[0] != null) if (dictionary.Contains(values[0])) return dictionary[values[0]];
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
           // if (value == null) return null;
            throw new NotImplementedException();
        }
    }
}