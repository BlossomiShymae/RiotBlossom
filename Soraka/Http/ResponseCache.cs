namespace Soraka.Http
{
	public static class ResponseCache
	{
		public static void UseBoundedResponseCache()
		{

		}

		public record BoundedResponseCache
		{
			public Func<string, string> GetResponse { get; init; } = default!;
			public Func<string, string> SetResponse { get; init; } = default!;
		}
	}
}
