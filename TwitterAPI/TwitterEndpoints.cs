using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter
{
	static class TwitterEndpoints
	{
		public const string GetStatusesHomeTimeline = "https://api.twitter.com/1.1/statuses/home_timeline.json";
		public const string GetStatusesMentionsTimeline = "https://api.twitter.com/1.1/statuses/mentions_timeline.json";
		public const string GetUsersShow = "https://api.twitter.com/1.1/users/show.json";
		public const string GetUserStream = "https://userstream.twitter.com/1.1/user.json";
	}
}
