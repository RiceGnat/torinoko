using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter;

namespace Torinoko
{
	static class Twitter
	{
		public static ITwitter DefaultAgent { get; set; }

		private static Dictionary<ulong, ITwitter> agents = new Dictionary<ulong, ITwitter>();
		public static IDictionary<ulong, ITwitter> UserAgents
		{
			get { return agents; }
		}

		//public static ITwitter API { get; set; }
		public static ITwitter Spoof { get; set; }
	}
}
