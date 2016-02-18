namespace Twitter.Authentication
{
	public interface ITwitterConsumerKeyStore
	{
		string ConsumerKey { get; }
		string ConsumerSecret { get; }
	}
}
