namespace Soraka.Dto.LolStatus
{
	internal record ContentDto
	{
		public string Locale { get; init; } = default!;
		public string Content { get; init; } = default!;
	}
}
