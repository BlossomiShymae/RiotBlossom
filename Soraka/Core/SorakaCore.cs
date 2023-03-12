using Soraka.Api;
using Soraka.Http;

namespace Soraka.Core
{
	public static class SorakaCore
	{
		public static SorakaApiCollection Use(SorakaCoreSettings settings)
		{
			return new SorakaApiCollection
			{
				Summoner = SummonerApi.Use(settings.HttpClient, settings.RiotApiKey, "na1", settings.MiddlewarePipeline)
			};
		}
	}

	public record SorakaCoreSettings
	{
		public HttpClient HttpClient { get; init; } = new();
		public string RiotApiKey { get; init; } = string.Empty;
		public Type.PlatformRoute PlatformRoute { get; init; } = Type.PlatformRoute.NorthAmerica;
		public RiotGamesClient.MiddlewarePipeline MiddlewarePipeline { get; init; } = new();
	}

	public record SorakaApiCollection
	{
		public SummonerApiCollection Summoner { get; init; } = new SummonerApiCollection();
	}
}
