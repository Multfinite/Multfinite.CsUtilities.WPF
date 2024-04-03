using System.IO;
using System.Windows.Media.Imaging;

namespace Multfinite.Utilities.WPF
{
	public static partial class Utilities
	{
		public static BitmapSource LoadImage(string filePath, int decodeHeight = 0, int decodeWidth = 0)
		{
			BitmapImage bi = new BitmapImage();

			bi.BeginInit();
			bi.StreamSource = File.OpenRead(filePath);
			if (decodeHeight != 0) bi.DecodePixelHeight = decodeHeight;
			if (decodeWidth != 0) bi.DecodePixelWidth = decodeWidth;
			bi.EndInit();

			return bi;
		}
	}
}