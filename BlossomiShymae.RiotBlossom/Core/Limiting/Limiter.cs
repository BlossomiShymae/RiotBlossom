using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Core.Calling;
using BlossomiShymae.RiotBlossom.Data.Constants;
using BlossomiShymae.RiotBlossom.Data.Constants.Types;

namespace BlossomiShymae.RiotBlossom.Core.Limiting
{
    public enum LimiterProvider
    {
        Null,
        Burst,
        Spread
    }

    public abstract class Limiter
    {
        protected readonly ConcurrentDictionary<Shard, Limit> ApplicationLimits = new();
        protected readonly ConcurrentDictionary<Shard, Limit> MethodLimits = new();
        protected readonly ConcurrentDictionary<Shard, int> ServiceRetryAfter = new();

        public virtual async Task ProcessRequestAsync(DataCall call, HttpRequestMessage req)
        {
           ServiceRetryAfter.TryGetValue(call.Shard!, out int serviceRetryAfter);
            if (serviceRetryAfter > 0)
            {
                var duration = ServiceRetryAfter[call.Shard!];

                Trace.WriteLine($"Encountered service retry-after: {duration} seconds");
                await Task.Delay(duration * 1000)
                    .ConfigureAwait(false);

                ServiceRetryAfter[call.Shard!] = 0;
            }

            ApplicationLimits.TryGetValue(call.Shard!, out Limit? applicationLimit);
            MethodLimits.TryGetValue(call.Shard!, out Limit? methodLimit);
            var applicationRetryAfter = applicationLimit?.RetryAfter ?? 0;
            var methodRetryAfter = methodLimit?.RetryAfter ?? 0;

            var overpermittedRetryAfter = applicationRetryAfter > methodRetryAfter ? applicationRetryAfter   : methodRetryAfter; 
            if (overpermittedRetryAfter > 0)
            {
                Trace.WriteLine($"Overpermitted limits, retry-after: {overpermittedRetryAfter} seconds");
                
                await Task.Delay(overpermittedRetryAfter * 1000)
                    .ConfigureAwait(false);
            }

            return;
        }

        public virtual void ProcessResponse(DataCall call, HttpResponseMessage res)
        {
            var applicationLimit = new Limit(res.Headers, XHeader.ApplicationLimit, XHeader.ApplicationCount);
            var methodLimit = new Limit(res.Headers, XHeader.MethodLimit, XHeader.MethodCount);

            try
            {
                ServiceRetryAfter[call.Shard!] = int.Parse(res.Headers.GetValues(XHeader.RetryAfter).FirstOrDefault()!);
            }
            catch (Exception)
            {
            }

            ApplicationLimits[call.Shard!] = applicationLimit;
            MethodLimits[call.Shard!] = methodLimit;
        }
    }
}