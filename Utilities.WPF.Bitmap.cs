/*
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Multfinite.Utilities.WPF
{
	public static partial class Utilities
	{
		public static Bitmap GetBitmap(this BitmapSource source)
		{
			Bitmap bmp = new Bitmap(
				source.PixelWidth,
				source.PixelHeight,
				System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
			BitmapData data = bmp.LockBits(
				new Rectangle(Point.Empty, bmp.Size),
				ImageLockMode.WriteOnly,
				PixelFormat.Format32bppPArgb);
			source.CopyPixels(
				Int32Rect.Empty,
				data.Scan0,
				data.Height * data.Stride,
				data.Stride);
			bmp.UnlockBits(data);
			return bmp;
		}
		public static BitmapSource GetBitmapSource(this Bitmap bitmap)
		{
			return GetBitmapSource(bitmap, PixelFormats.Bgr24);
		}

		public static BitmapSource GetBitmapSource(this Bitmap bitmap, System.Windows.Media.PixelFormat format)
		{
			var bitmapData = bitmap.LockBits(
				new Rectangle(0, 0, bitmap.Width, bitmap.Height),
				ImageLockMode.ReadOnly, bitmap.PixelFormat);

			var bitmapSource = BitmapSource.Create(
				bitmapData.Width, bitmapData.Height, 96, 96, format, null,
				bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);

			bitmap.UnlockBits(bitmapData);
			return bitmapSource;
			//return bitmap.CreateBitmapSourceFromBitmap();
		}
	}
}
*/