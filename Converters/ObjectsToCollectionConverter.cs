using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Multfinite.Utilities.WPF.Converters
{
    public sealed class ObjectsToCollectionConverter : IMultiValueConverter, IValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ICollection<object> objects = new List<object>();
            foreach (var obj in values) objects.Add(obj);
            return objects.ToArray();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ICollection<object> objects = new List<object>();
            objects.Add(value);
            objects.Add(parameter);
            return objects;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => ((object[]) value).ToArray();

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<object> obj = (List<object>) value;
            return obj[0];
        }
    }
}