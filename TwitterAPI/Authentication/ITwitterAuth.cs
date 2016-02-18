using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Authentication
{
	public interface ITwitterAuth
	{
		//string ConsumerKey { get; }
		//string ConsumerSecret { get; }
		//string RequestToken { get; }
		//string RequestTokenSecret { get; }
		//string Verifier { get; }
		string AccessToken { get; }
		string AccessTokenSecret { get; }
		string UserId { get; }
		string ScreenName { get; }

		Task GetRequestToken();
		Task AuthenticateUser();
		Task GetAccessToken();

		Task<string> AuthorizedGet(string requestUrl, string queryString);
	}
}
