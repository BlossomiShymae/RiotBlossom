using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Core.Utils;

namespace BlossomiShymae.RiotBlossom.Core.Limiting
{
    public class Limit
    {
        /// <summary>
        /// The total requests permitted in a span.
        /// </summary>
        public int[] Count { get; init; } = [];
        /// <summary>
        /// The duration of the span.
        /// </summary>
        public int[] Seconds { get; init; } = [];
        /// <summary>
        /// The current requests in a span.
        /// </summary>
        public int[] Counter { get; set; } = [];
        /// <summary>
        /// The duration of the overpermitted span to wait.
        /// </summary>
        public int RetryAfter { get; set; }

        public Limit(HttpResponseHeaders headers, string limitKey, string counterKey)
        {
            var limitHeader = ExtractHeader(headers, limitKey);
            var counterHeader = ExtractHeader(headers, counterKey);
            
            Count = limitHeader.Select(l => l[0]).ToArray();
            Seconds = limitHeader.Select(l => l[1]).ToArray();
            Counter = counterHeader.Select(l => l[0]).ToArray();

            if (Count.Length != Counter.Length)
            {
                throw new InvalidOperationException("Rate limit has unbalanced headers!");
            }

            for (int i = 0; i < Count.Length; i++)
            {
                if (Counter[i] + 1 >= Count[i])
                {
                    if (RetryAfter < Seconds[i])
                    {
                        RetryAfter = Seconds[i];
                    }
                }
            }
        }

        private static int[][] ExtractHeader(HttpResponseHeaders headers, string key)
        {
            var value = headers.GetValues(key).FirstOrDefault() 
                ?? throw new NullReferenceException($"Header value for {key} is null");

            var values = value
                .Split(',', StringSplitOptions.RemoveEmptyEntries);

            var header = values
                .Select(x => x
                    .Split(':', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray())
                .ToArray();

            return header;
        }
    }
}