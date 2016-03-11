using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
		[JsonConverter(typeof(TargetObjectConverter))]
		public object TargetObject { get; set; }

		public T GetTargetObject<T>()
		{
			return (T)TargetObject;
		}

		//[DataMember(Name = "target_object", IsRequired = false)]
		//public Tweet TargetTweet { get; set; }

		//[DataMember(Name = "target_object", IsRequired = false)]
		//public object TargetList { get; set; }

		[DataMember(Name = "warning")]
		public StreamWarning Warning { get; set; }

		private class TargetObjectConverter : JsonConverter
		{
			public override bool CanConvert(Type objectType)
			{
				return objectType == typeof(Tweet);
			}

			public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
			{
				JObject jObject = JObject.Load(reader);
				object obj = null;

				// Check properties to determine type
				if (jObject.Property("slug") != null)
				{   // List
					// To be implemented
				}
				else if (jObject.Property("favorited") != null && jObject.Property("retweeted") != null)
				{   // Tweet
					obj = serializer.Deserialize<Tweet>(jObject.CreateReader());
				}
				return obj;
			}

			public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
			{
				throw new NotImplementedException("This converter is not needed to serialize JSONs.");
			}
		}
	}
}
