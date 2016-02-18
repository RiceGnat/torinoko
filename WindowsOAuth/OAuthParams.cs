using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsOAuth
{
	/// <summary>
	/// Manages OAuth parameters.
	/// </summary>
	public class OAuthParams
	{
		private Dictionary<string, string> p = new Dictionary<string, string>();

		private const string CALLBACK = "oauth_callback";
		/// <summary>
		/// Gets or sets the <c>oauth_callback</c> parameter.
		/// </summary>
		public string Callback
		{
			get { return GetKey(CALLBACK); }
			set { SetKey(CALLBACK, value); }
		}

		private const string CONSUMER_KEY = "oauth_consumer_key";
		/// <summary>
		/// Gets or sets the <c>oauth_consumer_key</c> parameter.
		/// </summary>
		public string ConsumerKey {
			get { return GetKey(CONSUMER_KEY); }
			set { SetKey(CONSUMER_KEY, value); }
		}

		private const string NONCE = "oauth_nonce";
		/// <summary>
		/// Gets or sets the <c>oauth_nonce</c> parameter.
		/// </summary>
		public string Nonce {
			get { return GetKey(NONCE); }
			set { SetKey(NONCE, value); }
		}

		private const string SIGNATURE = "oauth_signature";
		/// <summary>
		/// Gets or sets the <c>oauth_signature</c> parameter.
		/// </summary>
		public string Signature
		{
			get { return GetKey(SIGNATURE); }
			set { SetKey(SIGNATURE, value); }
		}

		private const string SIGNATURE_METHOD = "oauth_signature_method";
		/// <summary>
		/// Gets or sets the <c>oauth_signature_method</c> parameter.
		/// </summary>
		public string SignatureMethod {
			get { return GetKey(SIGNATURE_METHOD); }
			set { SetKey(SIGNATURE_METHOD, value); }
		}

		private const string TIMESTAMP = "oauth_timestamp";
		/// <summary>
		/// Gets or sets the <c>oauth_timestamp</c> parameter.
		/// </summary>
		public string Timestamp {
			get { return GetKey(TIMESTAMP); }
			set { SetKey(TIMESTAMP, value); }
		}

		private const string TOKEN = "oauth_token";
		/// <summary>
		/// Gets or sets the <c>oauth_token</c> parameter.
		/// </summary>
		public string Token {
			get { return GetKey(TOKEN); }
			set { SetKey(TOKEN, value); }
		}

		private const string TOKEN_SECRET = "oauth_token_secret";
		/// <summary>
		/// Gets or sets the <c>oauth_token_secret</c> parameter.
		/// </summary>
		public string TokenSecret
		{
			get { return GetKey(TOKEN_SECRET); }
			set { SetKey(TOKEN_SECRET, value); }
		}

		private const string VERIFIER = "oauth_verifier";
		/// <summary>
		/// Gets or sets the <c>oauth_verifier</c> parameter.
		/// </summary>
		public string Verifier {
			get { return GetKey(VERIFIER); }
			set { SetKey(VERIFIER, value); }
		}

		private const string VERSION = "oauth_version";
		/// <summary>
		/// Gets or sets the <c>oauth_version</c> parameter.
		/// </summary>
		public string Version {
			get { return GetKey(VERSION); }
			set { SetKey(VERSION, value); }
		}

		/// <summary>
		/// Gets a specified parameter by key.
		/// <remarks>May be used with <see cref="SetKey"/> to store and retrieve arbitrary non-OAuth parameters.</remarks>
		/// </summary>
		/// <param name="key">The name of the parameter.</param>
		/// <returns>The value of the parameter.</returns>
		public string GetKey(string key)
		{
			if (p.ContainsKey(key)) return p[key];
			else return null;
		}

		/// <summary>
		/// Sets a specified parameter by key.
		/// <remarks>May be used with <see cref="GetKey"/> to store and retrieve arbitrary non-OAuth parameters.</remarks>
		/// </summary>
		/// <param name="key">The name of the parameter.</param>
		/// <param name="value">The value of the parameter.</param>
		public void SetKey(string key, string value)
		{
			p[key] = value;
		}

		private string BuildString(string selectFormat, string aggregateFormat)
		{
			return p.Where(kv => !String.IsNullOrEmpty(kv.Value))
					.OrderBy(kv => kv.Key)
					.Select(kv => String.Format(selectFormat, kv.Key, kv.Value))
					.Aggregate((i, j) => String.Format(aggregateFormat, i, j));
		}

		/// <summary>
		/// Sorts and compiles all OAuth parameters into a string of the format <c>key1=value1&key2=value2...</c>
		/// <remarks>This method will include any non-OAuth parameters set using <see cref="SetKey"/>.</remarks>
		/// </summary>
		/// <returns>The parameter string.</returns>
		public string GetParamString()
		{
			return BuildString("{0}={1}", "{0}&{1}");
		}

		/// <summary>
		/// Sorts and compiles all OAuth parameters into a string of the format <c>key1="value1", key2="value2"...</c> for use in request headers.
		/// <remarks>This method will include any non-OAuth parameters set using <see cref="SetKey"/>.</remarks>
		/// </summary>
		/// <returns>The header parameter string.</returns>
		public string GetHeaderString()
		{
			return BuildString("{0}=\"{1}\"", "{0}, {1}");
		}
	}
}
