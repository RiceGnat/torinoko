using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;
using Windows.Web.Http;
using Windows.Web.Http.Headers;

namespace WindowsOAuth
{
	public class RequestUtil
	{
		private static async Task ShowErrorDialog(string url, HttpStatusCode statusCode)
		{
			await NotifyUser.ShowDialog(String.Format("Call to {0} failed. ({1}: {2})", url, (uint)statusCode, statusCode));
		}

		private static async Task<string> MakeRequest(string url, OAuthParams oAuthParams, string method, string postData = null)
		{
			HttpClient http = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage();
			request.Method = new HttpMethod(method);
			request.RequestUri = new Uri(url, UriKind.Absolute);
			request.Headers.Authorization = new HttpCredentialsHeaderValue("OAuth", oAuthParams.GetHeaderString());

			HttpResponseMessage response = await http.SendRequestAsync(request);
			if (response.IsSuccessStatusCode)
				return await response.Content.ReadAsStringAsync();
			else {
				await ShowErrorDialog(url, response.StatusCode);
				return null;
			}
		}

		public static async Task<string> Get(string url, OAuthParams oAuthParams, string queryString = null)
		{
			if (!String.IsNullOrWhiteSpace(queryString))
			{
				url = String.Format("{0}?{1}", url, queryString);
			}

			return await MakeRequest(url, oAuthParams, "GET");
		}

		public static async Task<string> Post(string url, OAuthParams oAuthParams, string postData = null)
		{
			return await MakeRequest(url, oAuthParams, "POST", postData);
		}

		public static async Task<string> WebAuthenticate(string startUrl, string endUrl, OAuthParams oAuthParams)
		{
			// WebAuthenticationBroker will open the Twitter login screen and capture the redirect after the user logs in
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
				await NotifyUser.ShowDialog("An error occured during authentication.");
			}

			return null;
		}

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
