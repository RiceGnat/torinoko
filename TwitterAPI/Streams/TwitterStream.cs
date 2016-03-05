using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace Twitter.Streams
{
	public enum TwitterStreamType
	{
		User,
		Site,
		Public
	}

	public class TwitterStream
	{
		private StreamReader reader;
		private Task readTask;

		public TwitterStreamType Type { get; private set; }
		public bool TaskRunning { get; private set; }

		private async Task Read()
		{
			while (TaskRunning)
			{
				string line = await reader.ReadLineAsync();

#if DEBUG
				System.Diagnostics.Debug.WriteLine(line);
#endif
			}
		}

		public void StartTask()
		{
			TaskRunning = true;
			readTask = Task.Run(Read);
		}

		public void StopTask()
		{
			TaskRunning = false;
		}

		public TwitterStream(IInputStream stream, TwitterStreamType type = TwitterStreamType.User)
		{
			Type = type;
			reader = new StreamReader(stream.AsStreamForRead());
		}
	}
}
