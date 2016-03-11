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
using Windows.UI.Xaml.Navigation;
using Twitter.Objects;
using static Torinoko.Utility;

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
			{   // Retweet
				RetweetRowDefinition.Height = new GridLength(0, GridUnitType.Auto);
				RetweetMessage.Text = "Retweeted by";
				RetweetUser.Text = " " + tweet.User.Name;

				displayedTweet = tweet.RetweetedStatus;
			}
			else
			{   // Normal tweet
				RetweetRowDefinition.Height = new GridLength(0, GridUnitType.Pixel);
				RetweetMessage.Text = String.Empty;
			}

			AuthorAvatar.Source = ImageSourceFromString(displayedTweet.User.ProfileImageUrl);
			AuthorName.Text = displayedTweet.User.Name;
			AuthorHandle.Text = "@" + displayedTweet.User.ScreenName;

			TweetText.Text = displayedTweet.Text;

			MediaPreviews.Children.Clear();
			if (displayedTweet.Entities.Media?.Length > 0)
			{   // Add media previews
				MediaPreviews.Visibility = Visibility.Visible;
				switch (displayedTweet.Entities.Media.Length)
				{
					case 1:
						Image preview = new Image();
						preview.Source = ImageSourceFromString(displayedTweet.Entities.Media[0].MediaUrl);
						preview.Style = (Style)Resources["MediaPreviewFull"];
						MediaPreviews.Children.Add(preview);
						//preview.MaxHeight = MediaPreviews.Width / 4 * 3;
						break;
				}
			}
			else
			{   // Hide media preview grid
				MediaPreviews.Visibility = Visibility.Collapsed;
			}
		}
	}
}
