using System.Collections.Generic;
using System.Threading.Tasks;
using Twitter.Objects;

namespace Twitter
{
	public interface ITwitter
	{
		IEnumerable<Tweet> HomeTimeline { get; }

		Task<bool> Authenticate();
		Task GetHomeTimeline();
	}
}
