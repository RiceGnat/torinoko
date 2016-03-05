using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Authentication
{
	static class TwitterOAuthEndpoints
	{
		public const string PostRequestToken = "https://api.twitter.com/oauth/request_token";
		public const string GetAuthenticate = "https://api.twitter.com/oauth/authenticate";
		public const string PostAccessToken = "https://api.twitter.com/oauth/access_token";
	}
}
