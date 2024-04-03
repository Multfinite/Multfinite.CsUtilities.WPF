using System;
using System.Globalization;
using System.Windows.Data;

namespace Multfinite.Utilities.WPF.Converters
{
	public enum UserInterfaceProviderType : byte
	{
		Boolean = 0,
		Multi = 1,

		Byte = 2,
		SByte = 3,
		Int16 = 4,
		UInt16 = 5,
		Int32 = 6,
		UInt32 = 7,
		Single = 8,
	}

	public sealed class DoubleToUInt32Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is uint) return value;
            double d = (double) value;
            return System.Convert.ToUInt32(d);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double) return value;
            uint i = (uint) value;
            return System.Convert.ToDouble(i);
        }
    }
    public sealed class DoubleToInt32Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int) return value;
            double d = (double)value;
            return System.Convert.ToInt32(d);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double) return value;
            int i = (int) value;
            return System.Convert.ToDouble(i);
        }
    }
    public sealed class DoubleToInt16Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is short) return value;
            double d = (double) value;
            return System.Convert.ToInt16(d);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double) return value;
            short i = (short) value;
            return System.Convert.ToDouble(i);
        }
    }
    public sealed class DoubleToUInt16Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ushort) return value;
            double d = (double)value;
            return System.Convert.ToUInt16(d);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double) return value;
            ushort i = (ushort)value;
            return System.Convert.ToDouble(i);
        }
    }
    public sealed class DoubleToByteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is byte) return value;
            double d = (double)value;
            return System.Convert.ToByte(d);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double) return value;
            byte i = (byte)value;
            return System.Convert.ToDouble(i);
        }
    }
    public sealed class DoubleToSByteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is sbyte) return value;
            double d = (double)value;
            return System.Convert.ToSByte(d);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double) return value;
            sbyte i = (sbyte)value;
            return System.Convert.ToDouble(i);
        }
    }
    public sealed class DoubleToSingleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is float) return value;
            double d = (double)value;
            return System.Convert.ToSingle(d);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double) return value;
            float i = (float)value;
            return System.Convert.ToDouble(i);
        }
    }

    public sealed class DoubleToConverter : IValueConverter
    {
        private static readonly DoubleToInt32Converter Int32Converter = new DoubleToInt32Converter();
        private static readonly DoubleToInt32Converter UInt32Converter = new DoubleToInt32Converter();
        private static readonly DoubleToInt16Converter Int16Converter = new DoubleToInt16Converter();
        private static readonly DoubleToUInt16Converter UInt16Converter = new DoubleToUInt16Converter();
        private static readonly DoubleToByteConverter  ByteConverter = new DoubleToByteConverter();
        private static readonly DoubleToSByteConverter SByteConverter = new DoubleToSByteConverter();
        private static readonly DoubleToSingleConverter SingleConverter = new DoubleToSingleConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            UserInterfaceProviderType type;
            if (parameter is string) type = (UserInterfaceProviderType) byte.Parse((string) parameter);
            else type = (UserInterfaceProviderType) parameter;
            
            switch (type)
            {
                case (UserInterfaceProviderType.Byte): return ByteConverter.Convert(value, targetType, null, culture);
                case (UserInterfaceProviderType.SByte): return SByteConverter.Convert(value, targetType, null, culture);

                case (UserInterfaceProviderType.Int16): return Int16Converter.Convert(value, targetType, null, culture);
                case (UserInterfaceProviderType.UInt16): return UInt16Converter.Convert(value, targetType, null, culture);

                case (UserInterfaceProviderType.Int32): return Int32Converter.Convert(value, targetType, null, culture);
                case (UserInterfaceProviderType.UInt32): return UInt32Converter.Convert(value, targetType, null, culture);

                case (UserInterfaceProviderType.Single): return SingleConverter.Convert(value, targetType, null, culture);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            UserInterfaceProviderType type;
            if (parameter is string) type = (UserInterfaceProviderType) byte.Parse((string) parameter);
            else type = (UserInterfaceProviderType) parameter;

            switch (type)
            {
                case (UserInterfaceProviderType.Byte): return ByteConverter.ConvertBack(value, targetType, null, culture);
                case (UserInterfaceProviderType.SByte): return SByteConverter.ConvertBack(value, targetType, null, culture);

                case (UserInterfaceProviderType.Int16): return Int16Converter.ConvertBack(value, targetType, null, culture);
                case (UserInterfaceProviderType.UInt16): return UInt16Converter.ConvertBack(value, targetType, null, culture);

                case (UserInterfaceProviderType.Int32): return Int32Converter.ConvertBack(value, targetType, null, culture);
                case (UserInterfaceProviderType.UInt32): return UInt32Converter.ConvertBack(value, targetType, null, culture);

                case (UserInterfaceProviderType.Single): return SingleConverter.ConvertBack(value, targetType, null, culture);
            }

            return null;
        }
    }
}