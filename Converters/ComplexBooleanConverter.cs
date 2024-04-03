using System;
using System.Globalization;
using System.Windows.Data;

namespace Multfinite.Utilities.WPF.Converters
{
    public sealed class AndBooleanConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var v in values) { if (!(bool) v) return false; }
            return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }

    public sealed class OrBooleanConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var v in values) { if ((bool)v) return true; }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
    /// <summary>
    /// for invert value setup parameter to 'i' symbol
    /// </summary>
    public sealed class BooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool invert = (string) parameter == "i";
            if ((bool) value)
            {
                if (invert) return false;
                else return true;
            }
            else
            {
                if (invert) return true;
                else return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool invert = (string) parameter == "i";
            if (invert) return !(bool) value;
            else return (bool) value;
        }
    }
}