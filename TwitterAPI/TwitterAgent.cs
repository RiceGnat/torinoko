using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsOAuth;
using Twitter.Authentication;

namespace Twitter
{
	public class TwitterAgent : ITwitter
	{
		private ITwitterAuth twitterAuth;

		private const string homeTimelineUrl = "https://api.twitter.com/1.1/statuses/home_timeline.json";

		public async Task<bool> Authenticate()
		{
			try
			{
				await twitterAuth.GetRequestToken();
				await twitterAuth.AuthenticateUser();
				await twitterAuth.GetAccessToken();
				return true;
			}
			catch (Exception ex)
			{
				await NotifyUser.ShowDialog("An error has occurred\n" + ex.Message);
				return false;
			}
		}

		public async Task GetHomeTimeline()
		{
			await twitterAuth.AuthorizedGet(homeTimelineUrl, String.Empty);
		}

		public TwitterAgent(ITwitterAuth twitterAuth)
		{
			this.twitterAuth = twitterAuth;
		}
	}
}
