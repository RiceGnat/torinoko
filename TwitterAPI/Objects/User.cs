using System;
using System.Runtime.Serialization;

namespace Twitter.Objects
{
	/// <summary>
	/// Represents a Twitter user.
	/// </summary>
	/// <remarks>
	/// https://dev.twitter.com/overview/api/users
	/// </remarks>
	[DataContract]
	public class User
	{
		/// <summary>
		/// Indicates that the user has an account with "contributor mode" enabled, allowing for tweets issued by the user to be co-authored by another account.
		/// </summary>
		/// <remarks>
		/// Rarely <c>true</c>.
		/// </remarks>
		[DataMember(Name = "contributors_enabled")]
		public bool ContributorsEnabled { get; set; }

		/// <summary>
		/// The UTC datetime that the user account was created on Twitter.
		/// </summary>
		[DataMember(Name = "created_at")]
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// When true, indicates that the user has not altered the theme or background of their user profile.
		/// </summary>
		[DataMember(Name = "default_profile")]
		public bool DefaultProfile { get; set; }

		/// <summary>
		/// When true, indicates that the user has not uploaded their own avatar and a default egg avatar is used instead.
		/// </summary>
		[DataMember(Name = "default_profile_image")]
		public bool DefaultProfileImage { get; set; }

		/// <summary>
		/// The user-defined UTF-8 string describing their account.
		/// </summary>
		/// <remarks>
		/// Nullable. 
		/// </remarks>
		[DataMember(Name = "description")]
		public string Description { get; set; }

		/// <summary>
		/// Entities which have been parsed out of the <see cref="Url"/> or <see cref="Description"/> fields defined by the user.
		/// </summary>
		[DataMember(Name = "entities")]
		public Entities Entities { get; set; }

		/// <summary>
		/// The number of tweets this user has favorited in the account's lifetime.
		/// </summary>
		[DataMember(Name = "favourites_count")]
		public uint FavoritesCount { get; set; }

		/// <summary>
		/// When true, indicates that the authenticating user has issued a follow request to this protected user account.
		/// </summary>
		/// <remarks>
		/// Nullable. Perspectival.
		/// </remarks>
		[DataMember(Name = "follow_request_sent")]
		public bool? FollowRequestSent { get; set; }

		/// <summary>
		/// Deprecated. When true, indicates that the authenticating user is following this user.
		/// </summary>
		/// <remarks>
		/// Nullable. Perspectival.
		/// Some false negatives are possible when set to "false," but these false negatives are increasingly being represented as "null" instead.
		/// </remarks>
		[DataMember(Name = "following")]
		public bool? Following { get; set; }

		/// <summary>
		/// The number of followers this account currently has.
		/// </summary>
		/// <remarks>
		/// Under certain conditions of duress, this field will temporarily indicate <c>0</c>.
		/// </remarks>
		[DataMember(Name = "followers_count")]
		public uint FollowersCount { get; set; }

		/// <summary>
		/// The number of users this account is following. Under certain conditions of duress, this field will temporarily indicate <c>0</c>.
		/// </summary>
		/// <remarks>
		/// Under certain conditions of duress, this field will temporarily indicate <c>0</c>.
		/// </remarks>
		[DataMember(Name = "friends_count")]
		public uint FriendsCount { get; set; }

		/// <summary>
		/// When true, indicates that the user has enabled the possibility of geotagging their tweets.
		/// </summary>
		/// <remarks>
		/// This field must be true for the current user to attach geographic data when using <c>POST statuses / update</c>.
		/// </remarks>
		[DataMember(Name = "geo_enabled")]
		public bool GeoEnabled { get; set; }

		/// <summary>
		/// The integer representation of the unique identifier for this user.
		/// </summary>
		/// <remarks>
		/// This number is greater than 53 bits.
		/// </remarks>
		[DataMember(Name = "id")]
		public ulong Id { get; set; }

		/// <summary>
		/// The string representation of the unique identifier for this user.
		/// </summary>
		[DataMember(Name = "id_str")]
		public string IdStr { get; set; }

		/// <summary>
		/// When true, indicates that the user is a participant in Twitter's translator community.
		/// </summary>
		[DataMember(Name = "is_translator")]
		public bool IsTranslator { get; set; }

		/// <summary>
		/// The BCP 47 code for the user's self-declared user interface language.
		/// </summary>
		/// <remarks>
		/// May or may not have anything to do with the content of their tweets.
		/// </remarks>
		[DataMember(Name = "lang")]
		public string Lang { get; set; }

		/// <summary>
		/// The number of public lists that this user is a member of.
		/// </summary>
		[DataMember(Name = "listed_count")]
		public uint ListedCount { get; set; }

		/// <summary>
		/// The user-defined location for this account's profile.
		/// </summary>
		/// <remarks>
		/// Nullable.
		/// Not necessarily a location nor parseable.
		/// </remarks>
		[DataMember(Name = "location")]
		public string Location { get; set; }

		/// <summary>
		/// The name of the user, as they've defined it.
		/// </summary>
		/// <remarks>
		/// Not necessarily a person's name. Typically capped at 20 characters, but subject to change.
		/// </remarks>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Deprecated. Indicates whether the authenticated user has chosen to receive this user's tweets by SMS. 
		/// </summary>
		/// <remarks>
		/// Nullable.
		/// </remarks>
		[DataMember(Name = "notifications")]
		public bool? Notifications { get; set; }

		/// <summary>
		/// The hexadecimal color chosen by the user for their background.
		/// </summary>
		[DataMember(Name = "profile_background_color")]
		public string ProfileBackgroundColor { get; set; }

		/// <summary>
		/// An HTTP-based URL pointing to the background image the user has uploaded for their profile.
		/// </summary>
		[DataMember(Name = "profile_background_image_url")]
		public string ProfileBackgroundImageUrl { get; set; }

		/// <summary>
		/// An HTTPS-based URL pointing to the background image the user has uploaded for their profile. 
		/// </summary>
		[DataMember(Name = "profile_background_image_url_https")]
		public string ProfileBackgroundImageUrlHttps { get; set; }

		/// <summary>
		/// When true, indicates that the user's <see cref="ProfileBackgroundImageUrl"/> should be tiled when displayed. 
		/// </summary>
		[DataMember(Name = "profile_background_tile")]
		public bool ProfileBackgroundTile { get; set; }

		/// <summary>
		/// The HTTPS-based URL pointing to the standard web representation of the user's uploaded profile banner.
		/// </summary>
		/// <remarks>
		/// By adding a final path element of the URL, different image sizes optimized for specific displays can be obtained.
		/// In the future, an API method will be provided to serve these URLs so that modifying the original URL is not neeeded.
		/// </remarks>
		[DataMember(Name = "profile_banner_url")]
		public string ProfileBannerUrl { get; set; }

		/// <summary>
		/// An HTTP-based URL pointing to the user's avatar image.
		/// </summary>
		[DataMember(Name = "profile_image_url")]
		public string ProfileImageUrl { get; set; }

		/// <summary>
		/// An HTTPS-based URL pointing to the user's avatar image. 
		/// </summary>
		[DataMember(Name = "profile_image_url_https")]
		public string ProfileImageUrlHttps { get; set; }

		/// <summary>
		/// The hexadecimal color the user has chosen to display links with in their Twitter UI. 
		/// </summary>
		[DataMember(Name = "profile_link_color")]
		public string ProfileLinkColor { get; set; }

		/// <summary>
		/// The hexadecimal color the user has chosen to display sidebar backgrounds with in their Twitter UI. 
		/// </summary>
		[DataMember(Name = "profile_sidebar_fill_color")]
		public string ProfileSidebarFillColor { get; set; }

		/// <summary>
		/// The hexadecimal color the user has chosen to display text with in their Twitter UI. 
		/// </summary>
		[DataMember(Name = "profile_text_color")]
		public string ProfileTextColor { get; set; }

		/// <summary>
		/// When true, indicates the user wants their uploaded background image to be used. 
		/// </summary>
		[DataMember(Name = "profile_use_background_image")]
		public bool ProfileUseBackgroundImage { get; set; }

		/// <summary>
		/// When true, indicates that this user has chosen to protect their tweets.
		/// </summary>
		[DataMember(Name = "protected")]
		public bool Protected { get; set; }

		/// <summary>
		/// The screen name, handle, or alias that this user identifies themselves with.
		/// </summary>
		/// <remarks>
		/// Screen names are unique but subject to change. Use <see cref="IdStr"/> as a user identifier whenever possible.
		/// Typically a maximum of 15 characters long, but some historical accounts may exist with longer names. 
		/// </remarks>
		[DataMember(Name = "screen_name")]
		public string ScreenName { get; set; }

		/// <summary>
		/// Indicates that the user would like to see media inline.
		/// </summary>
		/// <remarks>
		/// Somewhat disused.
		/// </remarks>
		[DataMember(Name = "show_all_inline_media")]
		public string ShowAllInlineMedia { get; set; }

		/// <summary>
		/// If possible, the user's most recent tweet or retweet.
		/// </summary>
		/// <remarks>
		/// Nullable.
		/// In some circumstances, this data cannot be provided and this field will be omitted, null, or empty.
		/// Perspectival attributes within tweets embedded within users cannot always be relied upon.
		/// </remarks>
		[DataMember(Name = "status")]
		public Tweet Status { get; set; }

		/// <summary>
		/// The number of tweets (including retweets) issued by the user.
		/// </summary>
		[DataMember(Name = "statuses_count")]
		public uint StatusesCount { get; set; }

		/// <summary>
		/// A string describing the time zone this user declares themselves within.
		/// </summary>
		/// <remarks>
		/// Nullable.
		/// </remarks>
		[DataMember(Name = "time_zone")]
		public string TimeZone { get; set; }

		/// <summary>
		/// A URL provided by the user in association with their profile. 
		/// </summary>
		/// <remarks>
		/// Nullable.
		/// </remarks>
		[DataMember(Name = "url")]
		public string Url { get; set; }

		/// <summary>
		/// The offset from GMT/UTC in seconds.
		/// </summary>
		/// <remarks>
		/// Nullable.
		/// </remarks>
		[DataMember(Name = "utc_offset")]
		public int? UtcOffset { get; set; }

		/// <summary>
		/// When true, indicates that the user has a verified account.
		/// </summary>
		[DataMember(Name = "verified")]
		public bool Verified { get; set; }

		/// <summary>
		/// When present, indicates a textual representation of the two-letter country codes this user is withheld from. 
		/// </summary>
		[DataMember(Name = "withheld_in_countries")]
		public string WithheldInCountries { get; set; }

		/// <summary>
		/// When present, indicates whether the content being withheld is the <c>"status"</c> or a <c>"user"</c>.
		/// </summary>
		[DataMember(Name = "withheld_scope")]
		public string WithheldScope { get; set; }
	}
}
