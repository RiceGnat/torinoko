using System.Runtime.Serialization;

namespace Twitter.Objects
{
	[DataContract]
	public class StreamWarning
	{
		[DataMember(Name = "code")]
		public string Code { get; set; }

		[DataMember(Name = "message")]
		public string Message { get; set; }

		[DataMember(Name = "user_id")]
		public ulong UserId { get; set; }
	}
}
