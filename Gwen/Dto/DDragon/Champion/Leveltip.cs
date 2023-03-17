using System.Collections.Immutable;

namespace Gwen.Dto.DDragon.Champion
{
	public record Leveltip
	{
		public ImmutableList<string> Label { get; init; } = ImmutableList<string>.Empty;
		public ImmutableList<string> Effect { get; init; } = ImmutableList<string>.Empty;
	}
}
