﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsOAuth;

namespace Twitter.Authentication
{
	/// <summary>
	/// Performs Twitter OAuth actions.
	/// </summary>
	public class TwitterOAuth : ITwitterAuth
	{
		private const string requestTokenUrl = "https://api.twitter.com/oauth/request_token";
		private const string authenticateUrl = "https://api.twitter.com/oauth/authenticate";
		private const string accessTokenUrl = "https://api.twitter.com/oauth/access_token";
		private const string callbackUrl = "test://callback";

		private ITwitterConsumerKeyStore keys;

		/// <summary>
		/// Gets the application's consumer key.
		/// </summary>
		public string ConsumerKey
		{
			get { return keys.ConsumerKey; }
		}

		/// <summary>
		/// Gets the application's consumer secret.
		/// </summary>
		public string ConsumerSecret
		{
			get { return keys.ConsumerSecret; }
		}

		/// <summary>
		/// Gets the request token received from the server.
		/// </summary>
		public string RequestToken { get; private set; }

		/// <summary>
		/// Gets the request token secret received from the server.
		/// </summary>
		public string RequestTokenSecret { get; private set; }

		/// <summary>
		/// Gets the token verifier received from the server.
		/// </summary>
		public string Verifier { get; private set; }

		/// <summary>
		/// Gets the access token received from the server.
		/// </summary>
		public string AccessToken { get; private set; }

		/// <summary>
		/// Gets the access token secret received from the server.
		/// </summary>
		public string AccessTokenSecret { get; private set; }

		/// <summary>
		/// Gets the user ID received from the server.
		/// </summary>
		public string UserId { get; private set; }

		/// <summary>
		/// Gets the screenname received from the server.
		/// </summary>
		public string ScreenName { get; private set; }

		private OAuthParams GetNewRequestParams()
		{
			string nonce = OAuthUtil.GetNonce();
			string timestamp = OAuthUtil.GetTimestamp();

			OAuthParams oAuthParams = new OAuthParams();
			oAuthParams.ConsumerKey = ConsumerKey;
			oAuthParams.Nonce = nonce;
			oAuthParams.SignatureMethod = "HMAC-SHA1";
			oAuthParams.Timestamp = timestamp;
			oAuthParams.Version = "1.0";

			return oAuthParams;
		}

		private void AddSignature(string requestMethod, string requestUrl, OAuthParams oAuthParams)
		{
			string paramString = oAuthParams.GetParamString();

			string baseString = String.Format("{0}&{1}&{2}",
				requestMethod,
				Uri.EscapeDataString(requestUrl),
				Uri.EscapeDataString(paramString));

			string signatureKey = String.Format("{0}&{1}",
				Uri.EscapeDataString(ConsumerSecret),
				Uri.EscapeDataString(AccessTokenSecret ?? String.Empty));

			string signature = OAuthUtil.GetSignature(baseString, signatureKey);
			oAuthParams.Signature = Uri.EscapeDataString(signature);
		}

		/// <summary>
		/// Sends a request for a request token for this application.
		/// </summary>
		public async Task GetRequestToken()
		{
			OAuthParams oAuthParams = GetNewRequestParams();
			oAuthParams.Callback = Uri.EscapeDataString(callbackUrl);

			AddSignature("POST", requestTokenUrl, oAuthParams);

			string response = await HttpUtil.Post(requestTokenUrl, oAuthParams);

			if (String.IsNullOrEmpty(response))
				throw new Exception("Failed getting request token.");

			OAuthParams responseParams = OAuthUtil.ParseResponse(response);
			RequestToken = responseParams.Token;
			RequestTokenSecret = responseParams.TokenSecret;

#if DEBUG
			System.Diagnostics.Debug.WriteLine("Request token: " + RequestToken);
			System.Diagnostics.Debug.WriteLine("Request token secret: " + RequestTokenSecret);
#endif
		}

		/// <summary>
		/// Prompts the user for authentication.
		/// </summary>
		public async Task AuthenticateUser()
		{
			OAuthParams oAuthParams = new OAuthParams{ Token = RequestToken };

			string response = await HttpUtil.WebAuthenticate(authenticateUrl, callbackUrl, oAuthParams);

			if (String.IsNullOrEmpty(response))
				throw new Exception("Failed to authenticate user.");

			OAuthParams responseParams = OAuthUtil.ParseResponse(response.Split('?')[1]);

			if (responseParams.Token != RequestToken)
				throw new Exception("Authentication result and request token mismatch.");

			Verifier = responseParams.Verifier;

#if DEBUG
			System.Diagnostics.Debug.WriteLine("Verifier: " + Verifier);
#endif
		}

		/// <summary>
		/// Exchanges the request token for an access token.
		/// </summary>
		public async Task GetAccessToken()
		{
			OAuthParams oAuthParams = GetNewRequestParams();
			oAuthParams.Token = RequestToken;
			oAuthParams.Verifier = Verifier;

			AddSignature("POST", accessTokenUrl, oAuthParams);

			string response = await HttpUtil.Post(accessTokenUrl, oAuthParams);

			if (String.IsNullOrEmpty(response))
				throw new Exception("Failed getting access token.");

			OAuthParams responseParams = OAuthUtil.ParseResponse(response);
			AccessToken = responseParams.Token;
			AccessTokenSecret = responseParams.TokenSecret;
			UserId = responseParams.GetKey("user_id");
			ScreenName = responseParams.GetKey("screen_name");

#if DEBUG
			System.Diagnostics.Debug.WriteLine("Access token: " + AccessToken);
			System.Diagnostics.Debug.WriteLine("Access token secret: " + AccessTokenSecret);
			System.Diagnostics.Debug.WriteLine("User ID: " + UserId);
			System.Diagnostics.Debug.WriteLine("Screen name: " + ScreenName);
#endif
		}

		/// <summary>
		/// Sends a GET request using the OAuth access token.
		/// </summary>
		/// <param name="requestUrl">The URL to send the request to.</param>
		/// <param name="queryString">The query string to be appended to the request URL. Do not include the '?'.</param>
		/// <returns>The response from the server as a string.</returns>
		public async Task<string> AuthorizedGet(string requestUrl, string queryString)
		{
			OAuthParams oAuthParams = GetNewRequestParams();
			oAuthParams.Token = AccessToken;

			AddSignature("GET", requestUrl, oAuthParams);

			return await HttpUtil.Get(requestUrl, oAuthParams, queryString);
		}

		/// <summary>
		/// Sends a POST request using the OAuth access token.
		/// </summary>
		/// <param name="requestUrl">The URL to send the request to.</param>
		/// <param name="postData">The data to be included in the request body.</param>
		/// <returns>The response from the server as a string.</returns>
		public async Task<string> AuthorizedPost(string requestUrl, string postData)
		{
			OAuthParams oAuthParams = GetNewRequestParams();
			oAuthParams.Token = AccessToken;

			AddSignature("POST", requestUrl, oAuthParams);

			return await HttpUtil.Post(requestUrl, oAuthParams, postData);
		}

		/// <summary>
		/// Creates a new <c>TwitterOAuth</c> instance with the provided consumer key and secret.
		/// </summary>
		/// <param name="keyStore">An object implementing <see cref="ITwitterConsumerKeyStore"/>.</param>
		public TwitterOAuth(ITwitterConsumerKeyStore keyStore)
		{
			keys = keyStore;
		}
	}
}
