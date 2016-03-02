using System.Runtime.Serialization;

namespace Twitter.Objects
{
	[DataContract]
	public class TwitterUrl
	{
		[DataMember(Name = "expanded_url")]
		public string ExpandedUrl { get; set; }

		[DataMember(Name = "url")]
		public string Url { get; set; }

		[DataMember(Name = "indices")]
		public int[] Indices { get; set; }

		[DataMember(Name = "display_url")]
		public string DisplayUrl { get; set; }
	}
}
