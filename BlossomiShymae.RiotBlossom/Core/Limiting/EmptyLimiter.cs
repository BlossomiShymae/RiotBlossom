using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Core.Calling;

namespace BlossomiShymae.RiotBlossom.Core.Limiting
{
    public class EmptyLimiter : Limiter
    {
        public async override Task ProcessRequestAsync(DataCall call, HttpRequestMessage req)
        {
            // NO-OP
            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        public override void ProcessResponse(DataCall call, HttpResponseMessage res)
        {
            // NO-OP
        }
    }
}