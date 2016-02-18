using System;
using System.Linq;
using System.Text.RegularExpressions;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;

namespace WindowsOAuth
{
	public static class OAuthUtil
	{
		public static string GetNonce()
		{
			Random r = new Random();
			byte[] buffer = new byte[32];
			r.NextBytes(buffer);
			return new Regex("[^0-9a-zA-Z]").Replace(Convert.ToBase64String(buffer), "");
		}

		public static string GetTimestamp()
		{
			TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			return Convert.ToInt64(ts.TotalSeconds).ToString();
		}

		public static string GetSignature(string baseString, string signingKey)
		{
			IBuffer keyMaterial = CryptographicBuffer.ConvertStringToBinary(signingKey, BinaryStringEncoding.Utf8);
			MacAlgorithmProvider hmacSha1Provider = MacAlgorithmProvider.OpenAlgorithm("HMAC_SHA1");
			CryptographicKey key = hmacSha1Provider.CreateKey(keyMaterial);
			IBuffer data = CryptographicBuffer.ConvertStringToBinary(baseString, BinaryStringEncoding.Utf8);
			IBuffer signature = CryptographicEngine.Sign(key, data);
			return CryptographicBuffer.EncodeToBase64String(signature);
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
