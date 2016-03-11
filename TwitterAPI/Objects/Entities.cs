using System.Runtime.Serialization;

namespace Twitter.Objects
{
	/// <summary>
	/// Contains metadata and additional contextual information about content posted on Twitter.
	/// </summary>
	/// <remarks>
	/// https://dev.twitter.com/overview/api/entities
	/// </remarks>
	[DataContract]
	public class Entities
	{
		/// <summary>
		/// Represents hashtags which have been parsed out of the tweet text.
		/// </summary>
		[DataMember(Name = "hashtags")]
		public Hashtag[] Hashtags { get; set; }

		/// <summary>
		/// Represents media elements uploaded with the tweet.
		/// </summary>
		[DataMember(Name = "media")]
		public Media[] Media { get; set; }

		/// <summary>
		/// Represents URLs included in the text of a tweet or within textual fields of a user object. 
		/// </summary>
		[DataMember(Name = "urls")]
		public Url[] Urls { get; set; }

		/// <summary>
		/// Represents other Twitter users mentioned in the text of the tweet.
		/// </summary>
		[DataMember(Name = "user_mentions")]
		public UserMention[] UserMentions { get; set; }
	}

	/// <summary>
	/// Contains metadata and contextual information about a hashtag parsed out of a tweet.
	/// </summary>
	[DataContract]
	public class Hashtag
	{
		/// <summary>
		/// An array of integers indicating the offsets within the tweet text where the hashtag begins and ends.
		/// </summary>
		/// <remarks>
		/// The first integer represents the location of the '#' character in the Tweet text string.
		/// The second integer represents the location of the first character after the hashtag.
		/// Therefore the difference between the two numbers will be the length of the hashtag name plus one (for the '#' character).
		/// </remarks>
		[DataMember(Name = "indices")]
		public int[] Indices { get; set; }

		/// <summary>
		/// Name of the hashtag, minus the leading '#' character.
		/// </summary>
		[DataMember(Name = "text")]
		public string Text { get; set; }

		/// <summary>
		/// The length of the hashtag (including the '#' character).
		/// </summary>
		[IgnoreDataMember]
		public int Length
		{
			get { return Indices == null || Indices.Length < 2 ? 0 : Indices[1] - Indices[0]; }
		}
	}

	/// <summary>
	/// Contains metadata and contextual information about media elements uploaded with a tweet.
	/// </summary>
	[DataContract]
	public class Media
	{
		/// <summary>
		/// URL of the media to display to clients.
		/// </summary>
		[DataMember(Name = "display_url")]
		public string DisplayUrl { get; set; }

		/// <summary>
		/// An expanded version of <see cref="DisplayUrl"/>. Links to the media display page.
		/// </summary>
		[DataMember(Name = "expanded_url")]
		public string ExpandedUrl { get; set; }

		/// <summary>
		/// ID of the media expressed as a 64-bit integer.
		/// </summary>
		[DataMember(Name = "id")]
		public ulong Id { get; set; }

		/// <summary>
		/// ID of the media expressed as a string.
		/// </summary>
		[DataMember(Name = "id_str")]
		public ulong IdStr { get; set; }

		/// <summary>
		/// An array of integers indicating the offsets within the Tweet text where the URL begins and ends.
		/// </summary>
		/// <remarks>
		/// The first integer represents the location of the first character of the URL in the Tweet text.
		/// The second integer represents the location of the first non-URL character occurring after the URL
		/// (or the end of the string if the URL is the last part of the Tweet text).
		/// </remarks>
		[DataMember(Name = "indices")]
		public int[] Indices { get; set; }

		/// <summary>
		/// An HTTP-based URL pointing directly to the uploaded media file. 
		/// </summary>
		/// <remarks>
		/// For media in direct messages, this is the same HTTPS URL as <see cref="MediaUrlHttps"/> and must be accessed via
		/// an authenticated twitter.com session or by signing a request with the user’s access token using OAuth 1.0A.
		/// It is not possible to directly embed these images in a web page.
		/// </remarks>
		[DataMember(Name = "media_url")]
		public string MediaUrl { get; set; }

		/// <summary>
		/// An HTTPS-based URL pointing directly to the uploaded media file, for embedding on HTTPS pages. 
		/// </summary>
		/// <remarks>
		/// For media in direct messages, this URL must be accessed via an authenticated twitter.com session or by
		/// signing a request with the user’s access token using OAuth 1.0A.
		/// It is not possible to directly embed these images in a web page.
		/// </remarks>
		[DataMember(Name = "media_url_https")]
		public string MediaUrlHttps { get; set; }

		/// <summary>
		/// An object showing available sizes for the media file. 
		/// </summary>
		[DataMember(Name = "sizes")]
		public Sizes Sizes { get; set; }

		/// <summary>
		/// For tweets containing media that was originally associated with a different tweet,
		/// this ID points to the original tweet. 
		/// </summary>
		[DataMember(Name = "source_status_id")]
		public ulong SourceStatusId { get; set; }

		/// <summary>
		/// For tweets containing media that was originally associated with a different tweet,
		/// this string-based ID points to the original tweet. 
		/// </summary>
		[DataMember(Name = "source_status_id_str")]
		public string SourceStatusIdStr { get; set; }

		/// <summary>
		/// Type of uploaded media.
		/// </summary>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		/// <summary>
		/// Wrapped URL for the media link. This corresponds with the URL embedded directly into the raw tweet text,
		/// and the values for the <see cref="Indices"/> parameter.
		/// </summary>
		[DataMember(Name = "url")]
		public string UrlText { get; set; }

		/// <summary>
		/// The length of the URL in the tweet text.
		/// </summary>
		[IgnoreDataMember]
		public int UrlLength
		{
			get { return Indices == null || Indices.Length < 2 ? 0 : Indices[1] - Indices[0]; }
		}
	}

	/// <summary>
	/// Represents the size of a media element.
	/// </summary>
	[DataContract]
	public class Size
	{
		/// <summary>
		/// Height in pixels of this size.
		/// </summary>
		[DataMember(Name = "h")]
		public int Height { get; set; }

		/// <summary>
		/// Width in pixels of this size.
		/// </summary>
		[DataMember(Name = "w")]
		public int Width { get; set; }

		/// <summary>
		/// Resizing method used to obtain this size.
		/// </summary>
		/// <remarks>
		/// A value of <c>"fit"</c> means that the media was resized to fit one dimension, keeping its native aspect ratio.
		/// A value of <c>"crop"</c> means that the media was cropped in order to fit a specific resolution. 
		/// </remarks>
		[DataMember(Name = "resize")]
		public string Resize { get; set; }
	}

	/// <summary>
	/// Represents various sizes available for a media element.
	/// </summary>
	[DataContract]
	public class Sizes
	{
		/// <summary>
		/// Information for a thumbnail-sized version of the media.
		/// </summary>
		[DataMember(Name = "thumb")]
		public Size Thumb { get; set; }

		/// <summary>
		/// Information for a large-sized version of the media.
		/// </summary>
		[DataMember(Name = "large")]
		public Size Large { get; set; }

		/// <summary>
		/// Information for a medium-sized version of the media.
		/// </summary>
		[DataMember(Name = "medium")]
		public Size Medium { get; set; }

		/// <summary>
		/// Information for a small-sized version of the media.
		/// </summary>
		[DataMember(Name = "small")]
		public Size Small { get; set; }
	}

	/// <summary>
	/// Contains metadata and contextual information about a URL parsed out of a tweet.
	/// </summary>
	[DataContract]
	public class Url
	{
		/// <summary>
		/// Version of the URL to display to clients.
		/// </summary>
		[DataMember(Name = "display_url")]
		public string DisplayUrl { get; set; }

		/// <summary>
		/// Expanded version of <see cref="ExpandedUrl"/>.
		/// </summary>
		[DataMember(Name = "expanded_url")]
		public string ExpandedUrl { get; set; }

		/// <summary>
		/// An array of integers representing offsets within the tweet text where the URL begins and ends.
		/// </summary>
		/// <remarks>
		/// The first integer represents the location of the first character of the URL in the tweet text.
		/// The second integer represents the location of the first non-URL character after the end of the URL.
		/// </remarks>
		[DataMember(Name = "indices")]
		public int[] Indices { get; set; }

		/// <summary>
		/// Wrapped URL, corresponding to the value embedded directly into the raw tweet text,
		/// and the values for the <see cref="indices"/> parameter.
		/// </summary>
		[DataMember(Name = "url")]
		public string UrlText { get; set; }

		/// <summary>
		/// The length of the URL in the tweet text.
		/// </summary>
		[IgnoreDataMember]
		public int UrlLength
		{
			get { return Indices == null || Indices.Length < 2 ? 0 : Indices[1] - Indices[0]; }
		}
	}

	/// <summary>
	/// Contains metadata and contextual information about a user mention parsed out of a tweet.
	/// </summary>
	[DataContract]
	public class UserMention
	{
		/// <summary>
		/// ID of the mentioned user expressed as a 64-bit integer.
		/// </summary>
		[DataMember(Name = "id")]
		public ulong Id { get; set; }

		/// <summary>
		/// ID of the mentioned user expressed as a string.
		/// </summary>
		[DataMember(Name = "id_str")]
		public ulong IdStr { get; set; }

		/// <summary>
		/// An array of integers representing offsets within the tweet text where the user reference begins and ends.
		/// </summary>
		/// <remarks>
		/// The first integer represents the location of the '@' character of the user mention.
		/// The second integer represents the location of the first non-screenname character following the user mention.
		/// </remarks>
		[DataMember(Name = "indices")]
		public int[] Indices { get; set; }

		/// <summary>
		/// Display name of the referenced user.
		/// </summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Screen name of the referenced user.
		/// </summary>
		[DataMember(Name = "screen_name")]
		public string ScreenName { get; set; }

		/// <summary>
		/// The length of the user mention in the tweet text (including the '@' character).
		/// </summary>
		[IgnoreDataMember]
		public int Length
		{
			get { return Indices == null || Indices.Length < 2 ? 0 : Indices[1] - Indices[0]; }
		}
	}
}
