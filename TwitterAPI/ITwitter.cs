using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Twitter.Objects;
using Twitter.Streams;

namespace Twitter
{
	public interface ITwitter
	{
		ulong UserId { get; }
		string UserHandle { get; }
		TwitterStream UserStream { get; }

		Task<bool> Authenticate();
		Task<User> GetUser();
		Task<User> GetUser(string userId, string screenName);
		Task<IEnumerable<Tweet>> GetHomeTimeline();
		Task<IEnumerable<Tweet>> GetMentions();
		Task OpenUserStream();
		Task GetActivity();
	}
}
