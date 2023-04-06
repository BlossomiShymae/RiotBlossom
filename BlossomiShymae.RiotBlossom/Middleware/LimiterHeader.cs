using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Middleware
{
    public record LimiterHeader(ImmutableArray<(int requestCount, int intervalSeconds)> RateLimiterArray);
}
