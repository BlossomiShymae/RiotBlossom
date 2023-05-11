using BlossomiShymae.RiotBlossom.Http;
using BlossomiShymae.RiotBlossom.Middleware;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Core
{
    public interface IRiotBlossomClientBuilder
    {
        /// <summary>
        /// Add an http client.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        IRiotBlossomClientBuilder AddHttpClient(HttpClient httpClient);
        /// <summary>
        /// Add a Riot API key.
        /// </summary>
        /// <param name="riotApiKey"></param>
        /// <returns></returns>
        IRiotBlossomClientBuilder AddRiotApiKey(string riotApiKey);
        /// <summary>
        /// Add the Riot middleware stack via builder.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        IRiotBlossomClientBuilder AddRiotMiddlewareStack(Func<IMiddlewareStackBuilder, IMiddlewareStackBuilder> builder);
        /// <summary>
        /// Add the Riot middleware stack.
        /// </summary>
        /// <param name="middlewareStack"></param>
        /// <returns></returns>
        IRiotBlossomClientBuilder AddRiotMiddlewareStack(MiddlewareStack middlewareStack);
        /// <summary>
        /// Add the Data middleware stack via builder.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        IRiotBlossomClientBuilder AddDataMiddlewareStack(Func<IMiddlewareStackBuilder, IMiddlewareStackBuilder> builder);
        /// <summary>
        /// Add the Data middleware stack.
        /// </summary>
        /// <param name="middlewareStack"></param>
        /// <returns></returns>
        IRiotBlossomClientBuilder AddDataMiddlewareStack(MiddlewareStack middlewareStack);
        /// <summary>
        /// Build a <see cref="IRiotBlossomClient"/>. Default values will be used if any value is not added.
        /// </summary>
        /// <returns></returns>
        IRiotBlossomClient Build();
    }

    public interface IMiddlewareStackBuilder
    {
        /// <summary>
        /// Add a <see cref="AlgorithmicLimiter"/>.
        /// </summary>
        /// <param name="algorithmicLimiter"></param>
        /// <returns></returns>
        IMiddlewareStackBuilder AddAlgorithmicLimiter(AlgorithmicLimiter algorithmicLimiter);
        /// <summary>
        /// Add a <see cref="InMemoryCache"/>.
        /// </summary>
        /// <param name="cache"></param>
        /// <returns></returns>
        IMiddlewareStackBuilder AddInMemoryCache(InMemoryCache cache);
        /// <summary>
        /// Add a <see cref="Retryer"/>.
        /// </summary>
        /// <param name="retryer"></param>
        /// <returns></returns>
        IMiddlewareStackBuilder AddRetryer(Retryer retryer);
        /// <summary>
        /// Add a <see cref="IRequestMiddleware"/>.
        /// </summary>
        /// <param name="requestMiddleware"></param>
        /// <returns></returns>
        IMiddlewareStackBuilder AddRequestMiddleware(IRequestMiddleware requestMiddleware);
        /// <summary>
        /// Add a <see cref="IResponseMiddleware"/>.
        /// </summary>
        /// <param name="responseMiddleware"></param>
        /// <returns></returns>
        IMiddlewareStackBuilder AddResponseMiddleware(IResponseMiddleware responseMiddleware);
        /// <summary>
        /// Add a <see cref="IRetryMiddleware"/>.
        /// </summary>
        /// <param name="retryMiddleware"></param>
        /// <returns></returns>
        IMiddlewareStackBuilder AddRetryMiddleware(IRetryMiddleware retryMiddleware);
        /// <summary>
        /// Build a <see cref="MiddlewareStack"/>. Out-of-the-box middleware will take priority over custom middleware
        /// if added.
        /// </summary>
        /// <returns></returns>
        MiddlewareStack Build();
    }

    internal class RiotBlossomClientBuilder : IRiotBlossomClientBuilder
    {
        private HttpClient? _httpClient;
        private string? _riotApiKey;
        private MiddlewareStack? _riotMiddlewareStack;
        private MiddlewareStack? _dataMiddlewareStack;

        public IRiotBlossomClientBuilder AddDataMiddlewareStack(Func<IMiddlewareStackBuilder, IMiddlewareStackBuilder> builder)
        {
            _dataMiddlewareStack = builder(new MiddlewareStackBuilder()).Build();
            return this;
        }

        public IRiotBlossomClientBuilder AddDataMiddlewareStack(MiddlewareStack middlewareStack)
        {
            _dataMiddlewareStack = middlewareStack;
            return this;
        }

        public IRiotBlossomClientBuilder AddHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            return this;
        }

        public IRiotBlossomClientBuilder AddRiotApiKey(string riotApiKey)
        {
            _riotApiKey = riotApiKey;
            return this;
        }

        public IRiotBlossomClientBuilder AddRiotMiddlewareStack(Func<IMiddlewareStackBuilder, IMiddlewareStackBuilder> builder)
        {
            _riotMiddlewareStack = builder(new MiddlewareStackBuilder()).Build();
            return this;
        }

        public IRiotBlossomClientBuilder AddRiotMiddlewareStack(MiddlewareStack middlewareStack)
        {
            _riotMiddlewareStack = middlewareStack;
            return this;
        }

        public IRiotBlossomClient Build()
        {
            string riotApiKey = _riotApiKey ?? string.Empty;

            HttpClient httpClient = _httpClient ?? new()
            {
                Timeout = TimeSpan.FromSeconds(15)
            };

            MiddlewareStack riotMiddlewareStack = _riotMiddlewareStack ?? new();
            MiddlewareStack dataMiddlewareStack = _dataMiddlewareStack ?? new();

            ComposableHttpClient composableRiotHttpClient = new(httpClient, riotMiddlewareStack);
            ComposableHttpClient composableDataHttpClient = new(httpClient, dataMiddlewareStack);

            RiotHttpClient riotHttpClient = new(composableRiotHttpClient, riotApiKey);
            CommunityDragonHttpClient communityDragonHttpClient = new(composableDataHttpClient);
            DataDragonHttpClient dataDragonHttpClient = new(composableDataHttpClient);
            MerakiAnalyticsHttpClient merakiAnalyticsHttpClient = new(composableDataHttpClient);

            return new RiotBlossomClient(riotHttpClient, communityDragonHttpClient, dataDragonHttpClient, merakiAnalyticsHttpClient);
        }
    }

    internal class MiddlewareStackBuilder : IMiddlewareStackBuilder
    {
        private AlgorithmicLimiter? _algorithmicLimiter;
        private InMemoryCache? _inMemoryCache;
        private Retryer? _retryer;
        private readonly List<IRequestMiddleware> _requestSeries = new();
        private readonly List<IResponseMiddleware> _responseSeries = new();
        private IRetryMiddleware? _retry;

        public IMiddlewareStackBuilder AddAlgorithmicLimiter(AlgorithmicLimiter algorithmicLimiter)
        {
            _algorithmicLimiter = algorithmicLimiter;
            return this;
        }

        public IMiddlewareStackBuilder AddInMemoryCache(InMemoryCache cache)
        {
            _inMemoryCache = cache;
            return this;
        }

        public IMiddlewareStackBuilder AddRequestMiddleware(IRequestMiddleware requestMiddleware)
        {
            _requestSeries.Add(requestMiddleware);
            return this;
        }

        public IMiddlewareStackBuilder AddResponseMiddleware(IResponseMiddleware responseMiddleware)
        {
            _responseSeries.Add(responseMiddleware);
            return this;
        }

        public IMiddlewareStackBuilder AddRetryer(Retryer retryer)
        {
            _retryer = retryer;
            return this;
        }

        public IMiddlewareStackBuilder AddRetryMiddleware(IRetryMiddleware retryMiddleware)
        {
            _retry = retryMiddleware;
            return this;
        }

        public MiddlewareStack Build()
        {
            if (_inMemoryCache != null)
            {
                _requestSeries.Insert(0, _inMemoryCache);
                _responseSeries.Insert(0, _inMemoryCache);
            }
            if (_algorithmicLimiter != null)
            {
                _requestSeries.Insert(0, _algorithmicLimiter);
                _responseSeries.Insert(0, _algorithmicLimiter);
            }
            if (_retryer != null)
                _retry = _retryer;

            return new MiddlewareStack
            {
                RequestSeries = _requestSeries.ToImmutableArray(),
                ResponseSeries = _responseSeries.ToImmutableArray(),
                Retry = _retry
            };
        }
    }
}
