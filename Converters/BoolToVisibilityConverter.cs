using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Multfinite.Utilities.WPF.Converters
{
    public sealed class BoolToVisibilityConverter : IValueConverter
    {

        // i - invert
        // OR
        // t - true
        // f - false
        // n - null
        // c - collapsed
        // v - visible
        // h - hidden
        // example:
        // n:c|f:h|t:v
        // null = collapsed
        // false = hidden
        // true = visible
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool invert = false;
            if (parameter != null) invert = ((string) parameter) == "i";
            bool? b = (bool?)value;
            if (invert || parameter == null)
            {
                Visibility v = Visibility.Visible;
                switch (b)
                {
                    case (null):
                    {
                        v = Visibility.Collapsed;
                    }
                        break;
                    case (true):
                    {
                        v = (invert) ? Visibility.Hidden : Visibility.Visible;
                    }
                        break;
                    case (false):
                    {
                        v = (invert) ? Visibility.Visible : Visibility.Hidden;
                    }
                        break;
                }
                return v;
            }
            else
            {
                Dictionary<byte, Visibility> keyToValue = ParseParameter();
                return keyToValue[GetKey(b)];

                byte GetKey(bool? v)
                {
                    switch (v)
                    {
                        case (null): return 0;
                        case (true): return 1;
                        case (false): return 2;
                    }
                    throw new ArgumentException();
                }
            }

            Dictionary<byte, Visibility> ParseParameter()
            {
                Dictionary<byte, Visibility> dict = new Dictionary<byte, Visibility>();
                string pars = (string) parameter;
                foreach (var kvp in pars.Split('|'))
                {
                    string[] pkvp = kvp.Split(':');
                    dict.Add(GetKey(pkvp[0]), GetValue(pkvp[1]));
                }
                AddDefaultKeys();
                return dict;

                byte GetKey(string k)
                {
                    switch (k)
                    {
                        case ("n"): return 0;
                        case ("t"): return 1;
                        case ("f"): return 2;
                    }
                    throw new ArgumentException();
                }
                Visibility GetValue(string v)
                {
                    switch (v)
                    {
                        case ("c"): return Visibility.Collapsed;
                        case ("v"): return Visibility.Visible;
                        case ("h"): return Visibility.Hidden;
                    }
                    throw new ArgumentException();
                }

                void AddDefaultKeys()
                {
                    bool? nb = null;
                    if(!dict.ContainsKey(0)) dict.Add(0, Visibility.Collapsed); // null
                    if(!dict.ContainsKey(1)) dict.Add(1, Visibility.Visible); // true
                    if(!dict.ContainsKey(2)) dict.Add(2, Visibility.Hidden); // false
                }
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}