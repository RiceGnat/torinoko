using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;
using Windows.Storage.Streams;
using Windows.Web.Http;
using Windows.Web.Http.Headers;

namespace WindowsOAuth
{
	/// <summary>
	/// Contains utility functions to assist with making OAuth requests.
	/// </summary>
	public class RequestUtil
	{
		private static async Task ShowErrorDialog(string url, HttpStatusCode statusCode)
		{
			await Dialogs.ShowDialog(String.Format("Call to {0} failed. ({1}: {2})", url, (uint)statusCode, statusCode));
		}

		private static async Task<HttpResponseMessage> MakeRequest(string url, OAuthParams oAuthParams, string method, string postData = null, HttpCompletionOption option = HttpCompletionOption.ResponseContentRead)
		{
			HttpClient http = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage();
			request.Method = new HttpMethod(method);
			request.RequestUri = new Uri(url, UriKind.Absolute);
			request.Headers.Authorization = new HttpCredentialsHeaderValue("OAuth", oAuthParams.GetHeaderString());

			HttpResponseMessage response = await http.SendRequestAsync(request, option);
			if (response.IsSuccessStatusCode)
				return response;
			else
			{
				await ShowErrorDialog(url, response.StatusCode);
				return null;
			}
		}

		/// <summary>
		/// Makes a GET request asynchronously with the provided OAuth headers.
		/// </summary>
		/// <param name="url">The URL to send the request to.</param>
		/// <param name="oAuthParams">The OAuth parameters that will be included in the request header.</param>
		/// <param name="queryString">The query string that will be appended to the request URL. Do not include the '?'.</param>
		/// <returns>The response from the server as a string.</returns>
		public static async Task<string> Get(string url, OAuthParams oAuthParams, string queryString = null)
		{
			if (!String.IsNullOrWhiteSpace(queryString))
			{
				url = String.Format("{0}?{1}", url, queryString);
			}

			HttpResponseMessage response = await MakeRequest(url, oAuthParams, "GET");
			return await response?.Content.ReadAsStringAsync();
		}

		/// <summary>
		/// Makes a POST request asynchronously with the provided OAuth headers.
		/// </summary>
		/// <param name="url">The URL to send the request to.</param>
		/// <param name="oAuthParams">The OAuth parameters that will be included in the request header.</param>
		/// <param name="postData">The data to be included in the request body.</param>
		/// <returns>The response from the server as a string.</returns>
		public static async Task<string> Post(string url, OAuthParams oAuthParams, string postData = null)
		{
			HttpResponseMessage response = await MakeRequest(url, oAuthParams, "POST", postData);
			return await response?.Content.ReadAsStringAsync();
		}

		/// <summary>
		/// Directs the user to a URL for authentication, then captures the server redirect and returns control to the application.
		/// </summary>
		/// <param name="startUrl">The URL to direct the user to for authentication.</param>
		/// <param name="endUrl">The callback URL which the server will redirect to following successful authentication.</param>
		/// <param name="oAuthParams">The OAuth parameters to send to the authentication URL as a query string.</param>
		/// <returns>The captured request from the server to the callback URL.</returns>
		public static async Task<string> WebAuthenticate(string startUrl, string endUrl, OAuthParams oAuthParams)
		{
			string url = String.Format("{0}?{1}", startUrl, oAuthParams.GetParamString());
			Uri startUri = new Uri(url, UriKind.Absolute);
			Uri endUri = new Uri(endUrl, UriKind.Absolute);
			WebAuthenticationResult result = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, startUri, endUri);

			if (result.ResponseStatus == WebAuthenticationStatus.Success)
			{
				return result.ResponseData.ToString();
			}
			else if (result.ResponseStatus == WebAuthenticationStatus.ErrorHttp)
			{
				await ShowErrorDialog(startUrl, (HttpStatusCode)result.ResponseErrorDetail);
			}
			else
			{
				await Dialogs.ShowDialog("An error occured during authentication.");
			}

			return null;
		}

		/// <summary>
		/// Sends a GET request asynchronously with the provided OAuth headers and opens a stream for the response.
		/// </summary>
		/// <param name="url">The URL to send the request to.</param>
		/// <param name="oAuthParams">The OAuth parameters that will be included in the request header.</param>
		/// <param name="queryString">The query string that will be appended to the request URL. Do not include the '?'.</param>
		/// <returns>The response stream.</returns>
		public static async Task<IInputStream> GetStream(string url, OAuthParams oAuthParams, string queryString = null)
		{
			HttpResponseMessage response = await MakeRequest(url, oAuthParams, "GET", null, HttpCompletionOption.ResponseHeadersRead);
			return await response?.Content.ReadAsInputStreamAsync();
		}

		/// <summary>
		/// Parse the response string from an OAuth request into its constituent parameters.
		/// </summary>
		/// <param name="response">The response string.</param>
		/// <returns>An <see cref="OAuthParams"/> object containing the parameters in the response string.</returns>
		public static OAuthParams ParseResponse(string response)
		{
			OAuthParams oAuth = new OAuthParams();
			foreach (string[] kv in response.Split('&').Select(param => param.Split('=')))
			{
				oAuth.SetKey(kv[0], kv[1]);
			}
			return oAuth;
		}
	}
}
