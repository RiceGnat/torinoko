using System.Runtime.Serialization;

namespace Twitter.Objects
{
	[DataContract]
	public class TwitterUrlList
	{
		[DataMember(Name = "urls")]
		public TwitterUrl[] Urls { get; set; }
	}
}
