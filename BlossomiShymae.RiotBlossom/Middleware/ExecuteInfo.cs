namespace BlossomiShymae.RiotBlossom.Middleware
{
    /// <summary>
    /// The executing information of a HTTP message in the request/response middleware cycle.
    /// </summary>
    public record ExecuteInfo
    {
        public string RoutingValue { get; init; } = string.Empty;
        public string MethodUri { get; init; } = string.Empty;
    }
}
