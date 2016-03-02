using System.Runtime.Serialization;

namespace Twitter.Objects
{
	[DataContract]
	public class Entities
	{
		[DataMember(Name = "url")]
		public TwitterUrlList Url { get; set; }

		[DataMember(Name = "description")]
		public string Description { get; set; }
	}
}
