namespace BlossomiShymae.RiotBlossom.Middleware
{
    /// <summary>
    /// The executing information of a HTTP message in the request/response middleware cycle.
    /// </summary>
    public record ExecuteInfo
    {
        /// <summary>
        /// The routing value for a HTTP message.
        /// </summary>
        public string RoutingValue { get; init; } = string.Empty;
        /// <summary>
        /// The method URI that was called for the HTTP message.
        /// </summary>
        public string MethodUri { get; init; } = string.Empty;
    }
}
