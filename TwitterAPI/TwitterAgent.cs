﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using WindowsOAuth;
using Twitter.Authentication;
using Twitter.Objects;

namespace Twitter
{
	public class TwitterAgent : ITwitter
	{
		private ITwitterAuth twitterAuth;

		private const string homeTimelineUrl = "https://api.twitter.com/1.1/statuses/home_timeline.json";

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
			get { return twitterAuth.ScreenName; }
		}

		private Tweet[] timeline;
		public IEnumerable<Tweet> HomeTimeline
		{
			get { return timeline; }
		}

		public async Task<bool> Authenticate()
		{
			try
			{
				await twitterAuth.GetRequestToken();
				await twitterAuth.AuthenticateUser();
				await twitterAuth.GetAccessToken();
				return true;
			}
			catch (Exception ex)
			{
				await Dialogs.ShowDialog("An error has occurred\n" + ex.Message);
				return false;
			}
		}

		public async Task GetHomeTimeline()
		{
			string response = await twitterAuth.AuthorizedGet(homeTimelineUrl, String.Empty);

			timeline = ReadJSON<Tweet[]>(response);
		}

		public async Task GetStream()
		{
			await twitterAuth.AuthorizedGetStream("https://userstream.twitter.com/1.1/user.json", String.Empty);
		}

		public TwitterAgent(ITwitterAuth twitterAuth)
		{
			this.twitterAuth = twitterAuth;
		}
	}
}
