using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Twitter.Objects;

namespace Twitter.Streams
{
	public enum TwitterStreamType
	{
		User,
		Site,
		Public
	}

	public class TwitterStreamMessage
	{
		public TwitterStreamType SourceStreamType { get; set; }
		public string OriginalText { get; set; }
		public UserStreamMessage UserMessage { get; set; }
	}

	public delegate void TwitterStreamMessageHandler(TwitterStreamMessage message);

	public class TwitterStream
	{
		private StreamReader reader;
		private Task readTask;

		public TwitterStreamType Type { get; private set; }
		public bool TaskRunning { get; private set; }

		private async Task Read()
		{
			// Capture loop
			while (TaskRunning)
			{
				// Read line from stream
				string messageStr = await reader.ReadLineAsync();

				// Don't parse blank keepalives
				if (!String.IsNullOrWhiteSpace(messageStr) && messageStr != "\n")
				{
					TwitterStreamMessage message = new TwitterStreamMessage();

					message.SourceStreamType = Type;
					message.OriginalText = messageStr;
					
					switch (Type)
					{
						case TwitterStreamType.User:
							message.UserMessage = TwitterAgent.ReadJSON<UserStreamMessage>(messageStr);
							break;
					}

					// Invoke delegates
					MessageReceived.Invoke(message);
				}
			}
		}

		public event TwitterStreamMessageHandler MessageReceived;

		internal void StartTask()
		{
			TaskRunning = true;
			readTask = Task.Run(Read);
		}

		internal void StopTask()
		{
			TaskRunning = false;
		}

		internal TwitterStream(IInputStream stream, TwitterStreamType type = TwitterStreamType.User)
		{
			Type = type;
			reader = new StreamReader(stream.AsStreamForRead());
		}
	}
}
