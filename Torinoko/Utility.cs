using System;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Torinoko
{
	static class Utility
	{
		public static ImageSource ImageSourceFromString(string path)
		{
			return new BitmapImage(new Uri(path));
		}
	}
}
