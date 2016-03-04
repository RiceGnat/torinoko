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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Torinoko.Controls
{
	public sealed partial class View : UserControl
	{
		public View()
		{
			this.InitializeComponent();
		}

		public string Label
		{
			get { return ViewLabel.Text; }
			set { ViewLabel.Text = value; }
		}

		public string UserHandle
		{
			get { return ViewUser.Text; }
			set { ViewUser.Text = value; }
		}

		public void Clear()
		{
			TweetStack.Children.Clear();
		}

		public void AddTweet(Tweet tweet)
		{
			TweetPanel tweetPanel = new TweetPanel();
			tweetPanel.SetContent(tweet);
			TweetStack.Children.Add(tweetPanel);
		}
	}
}
