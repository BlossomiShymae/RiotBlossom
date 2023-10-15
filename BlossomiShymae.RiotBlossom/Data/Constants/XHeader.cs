namespace BlossomiShymae.RiotBlossom.Data.Constants
{
    public static class XHeader
    {
        public static readonly string ApplicationLimit = "x-app-rate-limit";
        public static readonly string ApplicationCount = "x-app-rate-limit-count";
        public static readonly string MethodLimit = "x-method-rate-limit";
        public static readonly string MethodCount = "x-method-rate-limit-count";
        public static readonly string RetryAfter = "retry-after";
    }
}
