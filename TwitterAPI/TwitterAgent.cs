using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using WindowsOAuth;
using Twitter.Authentication;
using Twitter.Objects;
using Twitter.Streams;

namespace Twitter
{
	public class TwitterAgent : ITwitter
	{
		private ITwitterConsumerKeyStore keys;
		private ITwitterAuth auth;

		private static readonly DataContractJsonSerializerSettings jsonSettings = new DataContractJsonSerializerSettings
		{
			DateTimeFormat = new DateTimeFormat("ddd MMM dd HH:mm:ss +0000 yyyy")
		};

		private static T ReadJSON<T>(string json)
		{
			MemoryStream stream = new MemoryStream();
			StreamWriter writer = new StreamWriter(stream);
			writer.Write(json);
			writer.Flush();
			stream.Position = 0;

			T obj = default(T);

			try
			{
				DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Tweet[]), jsonSettings);
				obj = (T)js.ReadObject(stream);
			}
			finally
			{
				stream.Dispose();
			}

			return obj;
		}

		public string UserHandle
		{
			get { return auth.ScreenName; }
		}

		public async Task<bool> Authenticate()
		{
			try
			{
				await auth.GetRequestToken();
				await auth.AuthenticateUser();
				await auth.GetAccessToken();
				return true;
			}
			catch (Exception ex)
			{
				await Dialogs.ShowDialog("An error has occurred.\n" + ex.Message);
				return false;
			}
		}

		public async Task<User> GetUser() => await GetUser(auth.UserId, auth.ScreenName);

		public async Task<User> GetUser(string userId, string screenName)
		{
			string response = await auth.AuthorizedGet(TwitterEndpoints.GetUsersShow);
			return ReadJSON<User>(response);
		}

		public async Task<IEnumerable<Tweet>> GetHomeTimeline()
		{
			string response = await auth.AuthorizedGet(TwitterEndpoints.GetStatusesHomeTimeline);
			return ReadJSON<Tweet[]>(response);
		}

		public async Task<IEnumerable<Tweet>> GetMentions()
		{
			string response = await auth.AuthorizedGet(TwitterEndpoints.GetStatusesMentionsTimeline);
			return ReadJSON<Tweet[]>(response);
		}

		public async Task GetActivity()
		{
			string response = await auth.AuthorizedGet(TwitterEndpoints.GetActivityAboutMe);
		}

		public async Task<TwitterStream> GetUserStream()
		{
			IInputStream stream = await auth.AuthorizedGetStream(TwitterEndpoints.GetUserStream);
			return new TwitterStream(stream);
		}

		private TwitterAgent() { }

		public TwitterAgent(ITwitterConsumerKeyStore keys)
		{
			this.keys = keys;
			auth = new TwitterOAuth(keys);
		}

		public static TwitterAgent NewOutOfBandAgent(ITwitterConsumerKeyStore keys)
		{
			TwitterAgent agent = new TwitterAgent();
			agent.keys = keys;
			agent.auth = new TwitterOAuth(keys, true);
			return agent;
		}
	}
}
