using System.Collections.Generic;
using System.Threading.Tasks;
using Twitter.Objects;

namespace Twitter
{
	public interface ITwitter
	{
		string UserHandle { get; }
		IEnumerable<Tweet> HomeTimeline { get; }

		Task<bool> Authenticate();
		Task GetHomeTimeline();
		Task GetStream();
	}
}
