namespace BlossomiShymae.RiotBlossom.Type
{
    public struct RiotHeader
    {
        public const string ApplicationLimit = "x-app-rate-limit";
        public const string ApplicationCount = "x-app-rate-limit-count";
        public const string MethodLimit = "x-method-rate-limit";
        public const string MethodCount = "x-method-rate-limit-count";
        public const string RetryAfter = "retry-after";
    }
}
