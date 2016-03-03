using System.Runtime.Serialization;

namespace Twitter.Objects
{
	/// <summary>
	/// Contains entities extracted from user objects.
	/// </summary>
	/// <remarks>
	/// https://dev.twitter.com/overview/api/entities-in-twitter-objects#users
	/// </remarks>
	[DataContract]
	public class UserEntities
	{
		/// <summary>
		/// Entities which have been parsed out of the <see cref="User.Description"/> field defined by the user.
		/// </summary>
		[DataMember(Name = "description")]
		public Entities FromDescription { get; set; }

		/// <summary>
		/// Entities which have been parsed out of the <see cref="User.Url"/> field defined by the user.
		/// </summary>
		[DataMember(Name = "url")]
		public Entities FromUrl { get; set; }
	}
}
