using System;
using System.Runtime.Serialization;

namespace Twitter.Objects
{
	/// <summary>
	/// Represents a tweet.
	/// </summary>
	/// <remarks>
	/// https://dev.twitter.com/overview/api/tweets
	/// </remarks>
	[DataContract]
	public class Tweet
	{
		/// <summary>
		/// Unused. Future/beta home for status annotations.
		/// </summary>
		[DataMember(Name = "annotations")]
		public object Annotations { get; set; }

		/// <summary>
		/// An collection of brief user objects (usually only one) indicating users who contributed to the authorship of the tweet, on behalf of the official tweet author.
		/// </summary>
		[DataMember(Name = "contributors")]
		public User Contributors { get; set; }

		/// <summary>
		/// Represents the geographic location of this tweet as reported by the user or client application.
		/// </summary>
		/// <remarks>
		/// Nullable. The inner coordinates array is formatted as geoJSON (longitude first, then latitude).
		/// </remarks>
		[DataMember(Name = "coordinates")]
		public string Coordinates { get; set; }

		/// <summary>
		/// UTC time when this tweet was created.
		/// </summary>
		[DataMember(Name = "created_at")]
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// Details the tweet ID of the user's own retweet (if existent) of this tweet.
		/// </summary>
		/// <remarks>
		/// Perspectival. Only surfaces on methods supporting the <c>include_my_retweet</c> parameter, when set to true.
		/// </remarks>
		[DataMember(Name = "current_user_retweet")]
		public Tweet CurrentUserRetweet { get; set; }

		/// <summary>
		/// Entities which have been parsed out of the text of the tweet.
		/// </summary>
		[DataMember(Name = "entities")]
		public Entities Entities { get; set; }

		/// <summary>
		/// Indicates approximately how many times this tweet has been favorited by Twitter users. 
		/// </summary>
		/// <remarks>Nullable.</remarks>
		[DataMember(Name = "favorite_count")]
		public uint? FavoriteCount { get; set; }

		/// <summary>
		/// Indicates whether this tweet has been liked by the authenticating user. 
		/// </summary>
		/// <remarks>
		/// Nullable. Perspectival.
		/// </remarks>
		[DataMember(Name = "favorited")]
		public bool? Favorited { get; set; }

		/// <summary>
		/// Indicates the maximum value of the <c>filter_level</c> parameter which may be used and still stream this tweet.
		/// </summary>
		/// <remarks>
		/// For example, a value of <c>"medium"</c> will be streamed on <c>"none"</c>, <c>"low"</c>, and <c>"medium"</c> streams.
		/// </remarks>
		[DataMember(Name = "filter_level")]
		public string FilterLevel { get; set; }

		/// <summary>
		/// Deprecated. Use the <see cref="Coordinates"/> field instead. 
		/// </summary>
		/// <remarks>
		/// Nullable.
		/// </remarks>
		[DataMember(Name = "geo")]
		public object Geo { get; set; }

		/// <summary>
		/// The integer representation of the unique identifier for this tweet.
		/// </summary>
		/// <remarks>
		/// This number is greater than 53 bits.
		/// </remarks>
		[DataMember(Name = "id")]
		public ulong Id { get; set; }

		/// <summary>
		/// The string representation of the unique identifier for this tweet.
		/// </summary>
		[DataMember(Name = "id_str")]
		public string IdStr { get; set; }

		/// <summary>
		/// If this tweet is a reply, this field will contain the screen name of the original tweet's author.
		/// </summary>
		/// <remarks>
		/// Nullable.
		/// </remarks>
		[DataMember(Name = "in_reply_to_screen_name")]
		public string InReplyToScreenName { get; set; }

		/// <summary>
		/// If this tweet is a reply, this field will contain the integer representation of the original tweet's ID. 
		/// </summary>
		/// <remarks>
		/// Nullable.
		/// </remarks>
		[DataMember(Name = "in_reply_to_status_id")]
		public ulong? InReplyToStatusId { get; set; }

		/// <summary>
		/// If this tweet is a reply, this field will contain the string representation of the original tweet's ID. 
		/// </summary>
		/// <remarks>
		/// Nullable.
		/// </remarks>
		[DataMember(Name = "in_reply_to_status_id_str")]
		public string InReplyToStatusIdString { get; set; }

		/// <summary>
		/// If this tweet is a reply, this field will contain the integer representation of the original tweet's author ID.
		/// </summary>
		/// <remarks>
		/// Nullable. This will not necessarily always be the user directly mentioned in the tweet.
		/// </remarks>
		[DataMember(Name = "in_reply_to_user_id")]
		public ulong? InReplyToUserId { get; set; }

		/// <summary>
		/// If this tweet is a reply, this field will contain the string representation of the original tweet's author ID.
		/// </summary>
		/// <remarks>
		/// Nullable. This will not necessarily always be the user directly mentioned in the tweet.
		/// </remarks>
		[DataMember(Name = "in_reply_to_user_id_str")]
		public string InReplyToUserIdString { get; set; }

		/// <summary>
		/// When present, indicates a BCP 47 language identifier corresponding to the machine-detected language of the tweet text,
		/// or <c>"und"</c> if no language could be detected.
		/// </summary>
		/// <remarks>
		/// Nullable.
		/// </remarks>
		[DataMember(Name = "lang")]
		public string Lang { get; set; }

		/// <summary>
		/// When present, indicates that the tweet is associated (but not necessarily originating from) a <see cref="Place"/>. 
		/// </summary>
		/// <remarks>
		/// Nullable.
		/// </remarks>
		[DataMember(Name = "place")]
		public Place Place { get; set; }

		/// <summary>
		/// An indicator that the URL contained in the tweet may contain content or media identified as sensitive content. 
		/// </summary>
		/// <remarks>
		/// Nullable. This field only surfaces when a tweet contains a link. The meaning of the field doesn't pertain to the tweet content itself.
		/// </remarks>
		[DataMember(Name = "possibly_sensitive")]
		public bool? PossiblySensitive { get; set; }

		/// <summary>
		/// This field contains the integer value tweet ID of the quoted tweet.
		/// </summary>
		/// <remarks>
		/// This field only surfaces when the tweet is a quote tweet.
		/// </remarks>
		[DataMember(Name = "quoted_status_id")]
		public ulong? QuotedStatusId { get; set; }

		/// <summary>
		/// This field contains the string representation tweet ID of the quoted tweet.
		/// </summary>
		/// <remarks>
		/// This field only surfaces when the tweet is a quote tweet.
		/// </remarks>
		[DataMember(Name = "quoted_status_id_str")]
		public string QuotedStatusIdStr { get; set; }

		/// <summary>
		/// This field contains the <see cref="Tweet"/> object of the original tweet that was quoted.
		/// </summary>
		/// <remarks>
		/// This field only surfaces when the tweet is a quote tweet.
		/// </remarks>
		[DataMember(Name = "quoted_status")]
		public Tweet QuotedStatus { get; set; }

		/// <summary>
		/// A set of key-value pairs indicating the intended contextual delivery of the containing tweet.
		/// </summary>
		/// <remarks>
		/// Currently used by Twitter's Promoted Products.
		/// </remarks>
		[DataMember(Name = "scopes")]
		public object Scopes { get; set; }

		/// <summary>
		/// Number of times this tweet has been retweeted.
		/// </summary>
		[DataMember(Name = "retweet_count")]
		public uint RetweetCount { get; set; }

		/// <summary>
		/// Indicates whether this tweet has been retweeted by the authenticating user.
		/// </summary>
		/// <remarks>
		/// Perspectival.
		/// </remarks>
		[DataMember(Name = "retweeted")]
		public bool Retweeted { get; set; }

		/// <summary>
		/// If this tweet is a retweet, contains the original tweet that was retweeted.
		/// </summary>
		/// <remarks>
		/// Note that retweets of retweets do not show representations of the intermediary retweet, but only the original tweet.
		/// </remarks>
		[DataMember(Name = "retweeted_status")]
		public Tweet RetweetedStatus { get; set; }

		/// <summary>
		/// Utility used to post the tweet, as an HTML-formatted string. Tweets from the Twitter website have a source value of <c>"web"</c>. 
		/// </summary>
		[DataMember(Name = "source")]
		public string Source { get; set; }

		/// <summary>
		/// The actual UTF-8 text of the status update.
		/// </summary>
		[DataMember(Name = "text")]
		public string Text { get; set; }

		/// <summary>
		/// Indicates whether the value of the text parameter was truncated.
		/// </summary>
		/// <remarks>
		/// Truncated text will end in an ellipsis. Since Twitter now rejects long tweets instead of truncating them,
		/// the large majority of tweets will have this set to <c>false</c>.
		/// Note that while native retweets may have their top level <see cref="Text"/> property shortened,
		/// the original text will be available under the <see cref="RetweetedStatus"/> object and the truncated parameter
		/// will be set to the value of the original status (in most cases, <c>false</c>). 
		/// </remarks>
		[DataMember(Name = "truncated")]
		public bool Truncated { get; set; }

		/// <summary>
		/// The user who posted this tweet.
		/// </summary>
		/// <remarks>
		/// Perspectival attributes embedded within this object are unreliable.
		/// </remarks>
		[DataMember(Name = "user")]
		public User User { get; set; }

		/// <summary>
		/// When present and set to <c>"true"</c>, it indicates that this piece of content has been withheld due to a DMCA complaint.
		/// </summary>
		[DataMember(Name = "withheld_copyright")]
		public bool WithheldCopyright { get; set; }

		/// <summary>
		/// When present, indicates a list of uppercase two-letter country codes this content is withheld from.
		/// </summary>
		/// <remarks>
		/// Twitter supports the following non-country values for this field:
		/// 
		/// <c>"XX"</c> - Content is withheld in all countries.
		/// 
		/// <c>"XY"</c> - Content is withheld due to a DMCA request.
		/// </remarks>
		[DataMember(Name = "withheld_in_countries")]
		public string[] WithheldInCountries { get; set; }

		/// <summary>
		/// When present, indicates whether the content being withheld is the <c>"status"</c> or a <c>"user"</c>.
		/// </summary>
		[DataMember(Name = "withheld_scope")]
		public string WithheldScope { get; set; }
	}

	/// <summary>
	/// Represents coordinates for a tweet.
	/// </summary>
	[DataContract]
	public class Coordinates
	{
		/// <summary>
		/// The longitude and latitude of the tweet's location. 
		/// </summary>
		/// <remarks>
		/// The first element is the longitude and the second is the latitude.
		/// </remarks>
		[DataMember(Name = "coordinates")]
		public float[] Values { get; set; }

		/// <summary>
		/// The type of data encoded in the coordinates property.
		/// </summary>
		/// <remarks>
		/// This will be <c>"Point"</c> for tweet coordinates fields. 
		/// </remarks>
		[DataMember(Name = "type")]
		public string Type { get; set; }
	}
}
