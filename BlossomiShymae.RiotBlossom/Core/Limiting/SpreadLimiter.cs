using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Core.Calling;
using BlossomiShymae.RiotBlossom.Data.Constants;

namespace BlossomiShymae.RiotBlossom.Core.Limiting
{
    public class SpreadLimiter : Limiter
    {

        public override async Task ProcessRequestAsync(DataCall call, HttpRequestMessage req)
        {
            await base.ProcessRequestAsync(call, req)
                .ConfigureAwait(false);

            List<TimeSpan> delays = new();

            ApplicationLimits.TryGetValue(call.Shard!, out Limit? applicationLimits);
            if (applicationLimits != null)
            {
                for (int i = 0; i < applicationLimits.Count.Length; i++)
                {
                    var span = TimeSpan.FromSeconds((double)applicationLimits.Seconds[i] / applicationLimits.Count[i]);

                    delays.Add(span);
                }
            }

            var delay = delays
                .OrderByDescending(x => x.Ticks)
                .First();

            await Task.Delay(delay)
                .ConfigureAwait(false);
        }

        public override void ProcessResponse(DataCall call, HttpResponseMessage res)
        {
            base.ProcessResponse(call, res);
        }
    }
}