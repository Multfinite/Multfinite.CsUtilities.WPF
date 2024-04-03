using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace Multfinite.Utilities.WPF.Converters
{
	public sealed class ImagePathToImageConverter : IValueConverter
    {
        // parameter:
        // x:Width|y:Height
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string file = (string) value;
            if (File.Exists(file))
            {
                if (parameter == null) return Utilities.LoadImage(file, 0, 0);
                else
                {
                    string[] str = ((string) parameter).Split('|');
                    int x = 0;
                    int y = 0;
                    foreach (var par in str)
                    {
                        string[] p = par.Split(':');
                        if (p[0] == "x") x = int.Parse(p[1]);
                        else if (p[0] == "y") y = int.Parse(p[1]);
                    }
                    return Utilities.LoadImage(file, x, y);
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}