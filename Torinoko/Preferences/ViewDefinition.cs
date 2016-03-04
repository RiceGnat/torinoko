using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torinoko.Preferences
{
	enum ViewType
	{
		Home,
		Notifications,
		User,
		Search
	}
	
	class ViewDefinition
	{
		public ViewType Type { get; set; }

		public bool ShowNotifications { get; set; }
		public bool StackNotifications { get; set; }

		public bool ShowFollowed { get; set; }
		public bool ShowFavorited { get; set; }
		public bool ShowRetweeted { get; set; }
		public bool ShowMentions { get; set; }
		public bool ShowQuotes { get; set; }
	}
}
