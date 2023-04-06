using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.XMiddleware
{
    public record XLimiterHeader(ImmutableArray<(int requestCount, int intervalSeconds)> RateLimiterArray);
}
