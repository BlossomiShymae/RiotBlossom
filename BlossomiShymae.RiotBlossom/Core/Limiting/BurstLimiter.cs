using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Core.Calling;
using BlossomiShymae.RiotBlossom.Data.Constants;

namespace BlossomiShymae.RiotBlossom.Core.Limiting
{
    public class BurstLimiter : Limiter
    {
        public override async Task ProcessRequestAsync(DataCall call, HttpRequestMessage req)
        {
            await base.ProcessRequestAsync(call, req)
                .ConfigureAwait(false);
        }

        public override void ProcessResponse(DataCall call, HttpResponseMessage res)
        {
            base.ProcessResponse(call, res);
        }
    }
}