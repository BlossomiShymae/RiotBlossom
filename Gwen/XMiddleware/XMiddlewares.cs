﻿using System.Collections.Immutable;

namespace Gwen.XMiddleware
{
    public record XMiddlewares
    {
        public ImmutableArray<IRequestMiddleware> XRequests { get; init; } = ImmutableArray.Create<IRequestMiddleware>(new IRequestMiddleware[]
        {
            XMemoryCache.Default,
            XLimiter.Default
        });
        public ImmutableArray<IResponseMiddleware> XResponses { get; init; } = ImmutableArray.Create<IResponseMiddleware>(new IResponseMiddleware[]
        {
            XMemoryCache.Default,
            XLimiter.Default
        });
        public IRetryMiddleware XRetry { get; init; } = XMiddleware.XRetry.Default;
    }
}
