using System.Collections.Immutable;

namespace Gwen.Dto.DDragon.Champion
{
	public record Leveltip
	{
		public ImmutableDictionary<int, string> Label { get; init; } = ImmutableDictionary<int, string>.Empty;
		public ImmutableDictionary<int, string> Effect { get; init; } = ImmutableDictionary<int, string>.Empty;
	}
}
