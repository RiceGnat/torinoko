namespace Twitter.Authentication
{
	/// <summary>
	/// Represents an object that will store the application's consumer key and secret.
	/// </summary>
	public interface ITwitterConsumerKeyStore
	{
		/// <summary>
		/// Gets the application's consumer key.
		/// </summary>
		string ConsumerKey { get; }

		/// <summary>
		/// Gets the application's consumer secret.
		/// </summary>
		string ConsumerSecret { get; }
	}
}
