//using Client.Utilities;
//using System;
//using System.Globalization;
//using System.IO;
//using System.Windows.Data;

//namespace Multfinite.Utilities.WPF.Converters
//{
//    public class PathToBitmapSourceConverter : IValueConverter
//    {
//        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
//        {
//            string fp = (string) value;
//            if (File.Exists(fp)) return ResourceLoader.LoadImage(fp);
//            return null;
//        }

//        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}