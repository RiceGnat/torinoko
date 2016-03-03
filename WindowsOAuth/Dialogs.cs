using System;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace WindowsOAuth
{
	public static class Dialogs
	{
		public static async Task ShowDialog(string message)
		{
			MessageDialog dialog = new MessageDialog(message);
			await dialog.ShowAsync();
		}
	}
}
