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
using Torinoko.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Torinoko
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();
		}

		protected override async void OnNavigatedTo(NavigationEventArgs e)
		{
			// Authenticate application and user
			bool authenticated = await Twitter.DefaultAgent.Authenticate();
			//bool authenticated2 = await Twitter.Spoof.Authenticate();

			if (!authenticated)
			{
				Window.Current.Close();
			}

			ViewColumn view = new ViewColumn();
			view.Label = "Home";
			view.UserHandle = "@" + Twitter.DefaultAgent.UserHandle;

			IEnumerable<Tweet> timeline = await Twitter.DefaultAgent.GetHomeTimeline();
			foreach (Tweet tweet in timeline)
			{
				view.AddTweet(tweet);
			}

			ViewSet.Children.Add(view);

			ViewColumn mentions = new ViewColumn();
			mentions.Label = "Mentions";
			mentions.UserHandle = "@" + Twitter.DefaultAgent.UserHandle;

			timeline = await Twitter.DefaultAgent.GetMentions();
			foreach (Tweet tweet in timeline)
			{
				mentions.AddTweet(tweet);
			}

			ViewSet.Children.Add(mentions);

			await Twitter.DefaultAgent.OpenUserStream();
			Twitter.DefaultAgent.UserStream.MessageReceived += (message) =>
			{
				if (message.UserMessage.Friends != null)
				{
					System.Diagnostics.Debug.WriteLine($"Preamble received. {message.UserMessage.Friends.Length} friend IDs.");
				}
				else
				{
					System.Diagnostics.Debug.WriteLine(message.UserMessage.EventName);
				}
			};
			//await Twitter.DefaultAgent.GetActivity();
			//await Twitter.Spoof.GetActivity();
		}
	}
}
