using System;
using System.Globalization;
using System.Windows.Data;

namespace Multfinite.Utilities.WPF.Converters
{
    public sealed class StringFormatConverter : IMultiValueConverter, IValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string formatStr = (string) parameter;

            int i = 0;
            while (true)
            {
                string str = string.Format("{0}{1}{2}", '{', i, '}');
                if (!formatStr.Contains(str)) break;
                formatStr = formatStr.Replace(str, values[i].ToString());
                i++;
            }
            return formatStr;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string formatStr = (string) parameter;
            return string.Format(formatStr, value);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}