using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace Multfinite.Utilities.WPF.Converters
{
	public class WpfNullableConverter : IValueConverter
	{
		public readonly NullableConverter Converter;

		public WpfNullableConverter(Type nullableType)
		{
			Converter = new NullableConverter(nullableType);
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			object converted = Converter.ConvertTo(value, value.GetType());
			return converted;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			object converted = Converter.ConvertFrom(value);
			return converted;
		}
	}
}