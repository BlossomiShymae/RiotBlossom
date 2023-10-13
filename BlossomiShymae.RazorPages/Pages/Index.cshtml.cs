using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlossomiShymae.RazorPages.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public List<LeagueShard> Shards = 
    [
        LeagueShard.NA1, LeagueShard.BR1, LeagueShard.LA1, LeagueShard.LA2,
        LeagueShard.EUW1, LeagueShard.EUN1, LeagueShard.TR1, LeagueShard.RU,
        LeagueShard.KR, LeagueShard.JP1,
        LeagueShard.OC1, LeagueShard.VN2, LeagueShard.SG2, LeagueShard.TH2, LeagueShard.PH2, LeagueShard.TW2
    ];

    public void OnGet()
    {

    }

    [BindProperty]
    public string? Name { get; set; }

    [BindProperty]
    public string? Shard { get; set; }

    public IActionResult OnPost()
    {
        return RedirectToPage("Summoners", new { Name, Shard });
    }
}
