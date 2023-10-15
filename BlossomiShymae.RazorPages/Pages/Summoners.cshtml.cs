using BlossomiShymae.RiotBlossom.Client;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Summoner;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlossomiShymae.RazorPages.Pages
{
    public class Summoners : PageModel
    {
        private readonly ILogger<Summoners> _logger;
        private readonly IRiotBlossomClient _client;

        public Summoners(ILogger<Summoners> logger, IRiotBlossomClient client)
        {
            _logger = logger;
            _client = client;
        }

        [BindProperty(SupportsGet = true)]
        public string? Name { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Shard { get; set; }

        public SummonerDto? MySummoner { get; set; }
        
        public string? ProfileIcon { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!ModelState.IsValid)
                return Redirect("Index");

            var shard = LeagueShard.GetFromValue(Shard.ToUpper());
            var summoner = await _client.SummonerV4.GetByNameAsync(shard, Name);
            MySummoner = summoner;
            ProfileIcon = _client.CommunityDragon.GetProfileIconById(summoner.ProfileIconId);

            return Page();
        }
    }
}