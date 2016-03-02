using System.Runtime.Serialization;

namespace Twitter.Objects
{
	[DataContract]
	public class TweetEntities
	{
		[DataMember(Name = "urls")]
		public string[] Urls { get; set; }

		[DataMember(Name = "hashtags")]
		public string[] Hashtags { get; set; }

		[DataMember(Name = "mentions")]
		public string[] Mentions { get; set; }
	}
}
