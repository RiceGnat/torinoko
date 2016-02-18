using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsOAuth
{
	public class OAuthParams
	{
		private Dictionary<string, string> p = new Dictionary<string, string>();

		private const string CALLBACK = "oauth_callback";
		public string Callback
		{
			get { return GetKey(CALLBACK); }
			set { SetKey(CALLBACK, value); }
		}

		private const string CONSUMER_KEY = "oauth_consumer_key";
		public string ConsumerKey {
			get { return GetKey(CONSUMER_KEY); }
			set { SetKey(CONSUMER_KEY, value); }
		}
		
		private const string NONCE = "oauth_nonce";
		public string Nonce {
			get { return GetKey(NONCE); }
			set { SetKey(NONCE, value); }
		}

		private const string SIGNATURE = "oauth_signature";
		public string Signature
		{
			get { return GetKey(SIGNATURE); }
			set { SetKey(SIGNATURE, value); }
		}

		private const string SIGNATURE_METHOD = "oauth_signature_method";
		public string SignatureMethod {
			get { return GetKey(SIGNATURE_METHOD); }
			set { SetKey(SIGNATURE_METHOD, value); }
		}
		
		private const string TIMESTAMP = "oauth_timestamp";
		public string Timestamp {
			get { return GetKey(TIMESTAMP); }
			set { SetKey(TIMESTAMP, value); }
		}
		
		private const string TOKEN = "oauth_token";
		public string Token {
			get { return GetKey(TOKEN); }
			set { SetKey(TOKEN, value); }
		}

		private const string TOKEN_SECRET = "oauth_token_secret";
		public string TokenSecret
		{
			get { return GetKey(TOKEN_SECRET); }
			set { SetKey(TOKEN_SECRET, value); }
		}

		private const string VERIFIER = "oauth_verifier";
		public string Verifier {
			get { return GetKey(VERIFIER); }
			set { SetKey(VERIFIER, value); }
		}
		
		private const string VERSION = "oauth_version";
		public string Version {
			get { return GetKey(VERSION); }
			set { SetKey(VERSION, value); }
		}

		public string GetKey(string key)
		{
			if (p.ContainsKey(key)) return p[key];
			else return null;
		}

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

		public string GetParamString()
		{
			return BuildString("{0}={1}", "{0}&{1}");
		}

		public string GetHeaderString()
		{
			return BuildString("{0}=\"{1}\"", "{0}, {1}");
		}
	}
}
