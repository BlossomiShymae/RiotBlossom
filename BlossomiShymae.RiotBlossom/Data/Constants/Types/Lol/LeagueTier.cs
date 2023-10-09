using BlossomiShymae.RiotBlossom.Core.Utils;

namespace BlossomiShymae.RiotBlossom.Data.Constants.Types.Lol
{
    /// <summary>
    /// <para>An enum that represents League ranks.</para>
    /// <see href="https://developer.riotgames.com/apis#league-v4"/>
    /// </summary>
    public sealed record LeagueTier : ValueEnum<string>
    {
        public static readonly LeagueTier Iron = new("IRON");
        public static readonly LeagueTier Bronze = new("BRONZE");
        public static readonly LeagueTier Silver = new("SILVER");
        public static readonly LeagueTier Gold = new("GOLD");
        public static readonly LeagueTier Platinum = new("PLATINUM");
        public static readonly LeagueTier Emerald = new("EMERALD");
        public static readonly LeagueTier Diamond = new("DIAMOND");

        private LeagueTier(string value) : base(value)
        {
        }
    }
}
