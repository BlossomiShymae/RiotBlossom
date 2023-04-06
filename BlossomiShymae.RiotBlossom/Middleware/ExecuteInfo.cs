namespace BlossomiShymae.RiotBlossom.Middleware
{
    public record ExecuteInfo
    {
        public string RoutingValue { get; init; } = string.Empty;
        public string MethodUri { get; init; } = string.Empty;
    }
}
