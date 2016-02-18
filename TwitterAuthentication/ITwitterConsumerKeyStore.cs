namespace TwitterAuthentication
{
	public interface ITwitterConsumerKeyStore
	{
		string ConsumerKey { get; }
		string ConsumerSecret { get; }
	}
}
