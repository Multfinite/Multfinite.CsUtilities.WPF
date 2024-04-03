using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Multfinite.Utilities.WPF.Converters
{
    public class ResourceDictionaryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ResourceDictionary dictionary = (ResourceDictionary) parameter;
            if(value != null) if (dictionary.Contains(value)) return dictionary[value];
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}