using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Twitter.Objects
{
	[DataContract]
	public class Tweet
	{
		[DataMember(Name = "coordinates")]
		public string Coordinates { get; set; }

		[DataMember(Name = "truncated")]
		public bool Truncated { get; set; }

		[DataMember(Name = "created_at")]
		public DateTime CreatedAt { get; set; }

		[DataMember(Name = "favorited")]
		public bool Favorited { get; set; }

		[DataMember(Name = "id_str")]
		public string IdString { get; set; }

		[DataMember(Name = "in_reply_to_user_id_str")]
		public bool InReplyToUserIdString { get; set; }

		[DataMember(Name = "entities")]
		public TweetEntities Entities { get; set; }

		[DataMember(Name = "text")]
		public string Text { get; set; }

		[DataMember(Name = "Contributors")]
		public string Contributors { get; set; }

		[DataMember(Name = "id")]
		public double Id { get; set; }

		[DataMember(Name = "retweet_count")]
		public long RetweetCount { get; set; }

		[DataMember(Name = "in_reply_to_status_id_str")]
		public string InReplyToStatusIdString { get; set; }

		[DataMember(Name = "geo")]
		public string Geo { get; set; }

		[DataMember(Name = "retweeted")]
		public bool Retweeted { get; set; }

		[DataMember(Name = "in_reply_to_user_id")]
		public double InReplyToUserId { get; set; }

		[DataMember(Name = "place")]
		public string Place { get; set; }

		[DataMember(Name = "source")]
		public string Source { get; set; }
	}
}
