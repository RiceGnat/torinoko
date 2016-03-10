using System;
using System.Runtime.Serialization;

namespace Twitter.Objects
{
	[DataContract]
	public class UserStreamMessage
	{
		[DataMember(Name = "friends")]
		public ulong[] Friends { get; set; }

		[DataMember(Name = "event")]
		public string EventName { get; set; }

		[DataMember(Name = "created_at")]
		public DateTime CreatedAt { get; set; }

		[DataMember(Name = "target")]
		public User TargetUser { get; set; }

		[DataMember(Name = "source")]
		public User SourceUser { get; set; }

		[DataMember(Name = "target_object")]
		public object TargetObject { get; set; }
		//[DataMember(Name = "target_object", IsRequired = false)]
		//public Tweet TargetTweet { get; set; }

		//[DataMember(Name = "target_object", IsRequired = false)]
		//public object TargetList { get; set; }
	}
}
