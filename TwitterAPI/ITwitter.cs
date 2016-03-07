using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Twitter.Objects;
using Twitter.Streams;

namespace Twitter
{
	public interface ITwitter
	{
		string UserHandle { get; }

		Task<bool> Authenticate();
		Task<IEnumerable<Tweet>> GetHomeTimeline();
		Task<IEnumerable<Tweet>> GetMentions();
		Task<User> GetUser();
		Task<User> GetUser(string userId, string screenName);
		Task<TwitterStream> GetUserStream();
	}
}
