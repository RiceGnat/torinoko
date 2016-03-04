using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Authentication
{
	/// <summary>
	/// Exposes methods necessary to perform the Twitter OAuth authentication flow.
	/// </summary>
	public interface ITwitterAuth
	{
		/// <summary>
		/// Gets the OAuth access token if the OAuth authentication process has been completed.
		/// </summary>
		string AccessToken { get; }

		/// <summary>
		/// Gets the OAuth access token secret if the OAuth authentication process has been completed.
		/// </summary>
		string AccessTokenSecret { get; }

		/// <summary>
		/// Gets the user ID if the OAuth authentication process has been completed.
		/// </summary>
		string UserId { get; }

		/// <summary>
		/// Gets the user ID if the OAuth authentication process has been completed.
		/// </summary>
		string ScreenName { get; }

		/// <summary>
		/// Sends a request for a request token, beginning the OAuth flow.
		/// </summary>
		Task GetRequestToken();

		/// <summary>
		/// Prompts the user for authentication.
		/// </summary>
		Task AuthenticateUser();

		/// <summary>
		/// Exchanges the request token for an access token, completing the OAuth flow.
		/// </summary>
		Task GetAccessToken();

		/// <summary>
		/// Sends a GET request using the OAuth access token.
		/// </summary>
		/// <param name="requestUrl">The URL to send the request to.</param>
		/// <param name="queryString">The query string to be appended to the request URL. Do not include the '?'.</param>
		/// <returns>The response from the server as a string.</returns>
		Task<string> AuthorizedGet(string requestUrl, string queryString = null);

		/// <summary>
		/// Sends a POST request using the OAuth access token.
		/// </summary>
		/// <param name="requestUrl">The URL to send the request to.</param>
		/// <param name="postData">The data to be included in the request body.</param>
		/// <returns>The response from the server as a string.</returns>
		Task<string> AuthorizedPost(string requestUrl, string postData = null);


		Task<string> AuthorizedGetStream(string requestUrl, string queryString = null);
	}
}
