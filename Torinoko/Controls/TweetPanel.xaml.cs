using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Twitter.Objects;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Torinoko.Controls
{
	public sealed partial class TweetPanel : UserControl
	{
		public TweetPanel()
		{
			this.InitializeComponent();
		}

		public void SetContent(Tweet tweet)
		{
			Tweet displayedTweet = tweet;

			if (tweet.RetweetedStatus != null)
			{	// Retweet
				RetweetRowDefinition.Height = new GridLength(0, GridUnitType.Auto);
				RetweetMessage.Text = "Retweeted by";
				RetweetUser.Text = " " + tweet.User.Name;

				displayedTweet = tweet.RetweetedStatus;
			}
			else
			{	// Normal tweet
				RetweetRowDefinition.Height = new GridLength(0, GridUnitType.Pixel);
				RetweetMessage.Text = String.Empty;
			}

			AuthorAvatar.Source = new BitmapImage(new Uri(displayedTweet.User.ProfileImageUrl, UriKind.Absolute));
			AuthorName.Text = displayedTweet.User.Name;
			AuthorHandle.Text = "@" + displayedTweet.User.ScreenName;

			TweetText.Text = displayedTweet.Text;
		}
	}
}
