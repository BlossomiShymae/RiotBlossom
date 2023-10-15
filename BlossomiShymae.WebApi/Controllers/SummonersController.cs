using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Client;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Summoner;
using Microsoft.AspNetCore.Mvc;

namespace BlossomiShymae.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SummonersController : ControllerBase
    {
        private readonly IRiotBlossomClient _client;

        public SummonersController(IRiotBlossomClient client)
        {
            _client = client;
        }

        [HttpGet("{name}/{shard}")]
        public async Task<SummonerDto> GetSummonerByNameAsync(string name, string shard)
        {
            var summoner = await _client.SummonerV4.GetByNameAsync(LeagueShard.GetFromValue(shard.ToUpper()), name);

            return summoner;
        }
    }
}