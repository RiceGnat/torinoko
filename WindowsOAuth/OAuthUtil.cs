using System;
using System.Linq;
using System.Text.RegularExpressions;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;

namespace WindowsOAuth
{
	/// <summary>
	/// Contains utility functions for OAuth.
	/// </summary>
	public static class OAuthUtil
	{
		/// <summary>
		/// Gets a random 32-character alphanumeric string.
		/// </summary>
		/// <returns>A random 32-character alphanumeric string.</returns>
		public static string GetNonce()
		{
			Random r = new Random();
			byte[] buffer = new byte[32];
			r.NextBytes(buffer);
			return new Regex("[^0-9a-zA-Z]").Replace(Convert.ToBase64String(buffer), "0");
		}

		/// <summary>
		/// Gets the current timestamp in seconds in Unix time.
		/// </summary>
		/// <returns>The timesetamp as a string.</returns>
		public static string GetTimestamp()
		{
			TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			return Convert.ToInt64(ts.TotalSeconds).ToString();
		}

		/// <summary>
		/// Gets the signature for the given string.
		/// </summary>
		/// <param name="baseString">The base string to be signed.</param>
		/// <param name="signingKey">The key used to sign the base string.</param>
		/// <returns>The signature as a base 64 string.</returns>
		public static string GetSignature(string baseString, string signingKey)
		{
			IBuffer keyMaterial = CryptographicBuffer.ConvertStringToBinary(signingKey, BinaryStringEncoding.Utf8);
			MacAlgorithmProvider hmacSha1Provider = MacAlgorithmProvider.OpenAlgorithm("HMAC_SHA1");
			CryptographicKey key = hmacSha1Provider.CreateKey(keyMaterial);
			IBuffer data = CryptographicBuffer.ConvertStringToBinary(baseString, BinaryStringEncoding.Utf8);
			IBuffer signature = CryptographicEngine.Sign(key, data);
			return CryptographicBuffer.EncodeToBase64String(signature);
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
