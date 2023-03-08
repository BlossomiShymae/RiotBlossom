namespace Soraka.Dto.Spectator
{
	internal record Observer
	{
		public string EncryptionKey { get; init; } = default!;
	}
}
