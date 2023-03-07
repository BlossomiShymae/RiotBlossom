using System.Collections.Immutable;

namespace Soraka.Core
{
	internal class LeagueDivisionMapper
	{
		private static readonly ImmutableDictionary<Type.LeagueDivision, string> _valueByLeagueDivision =
			new Dictionary<Type.LeagueDivision, string>
			{
				{ Type.LeagueDivision.I, "I" },
				{ Type.LeagueDivision.II, "II" },
				{ Type.LeagueDivision.III, "III" },
				{ Type.LeagueDivision.IV, "IV" }
			}.ToImmutableDictionary();

		public static string GetValue(Type.LeagueDivision leagueDivision)
		{
			var value = _valueByLeagueDivision.GetValueOrDefault(leagueDivision);
			if (string.IsNullOrEmpty(value))
				throw new NotImplementedException($"Value for league division {leagueDivision} is not implemented");
			return value;
		}
	}
}
