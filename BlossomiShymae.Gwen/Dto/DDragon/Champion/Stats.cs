namespace BlossomiShymae.Gwen.Dto.DDragon.Champion
{
    public record Stats
    {
        public double Hp { get; init; }
        public double Hpperlevel { get; init; }
        public double Mp { get; init; }
        public double Mpperlevel { get; init; }
        public double Movespeed { get; init; }
        public double Armor { get; init; }
        public double Armorperlevel { get; init; }
        public double Spellblock { get; init; }
        public double Spellblockperlevel { get; init; }
        public double Attackrange { get; init; }
        public double Hpregen { get; init; }
        public double Hpregenperlevel { get; init; }
        public double Mpregen { get; init; }
        public double Mpregenperlevel { get; init; }
        public double Crit { get; init; }
        public double Critperlevel { get; init; }
        public double Attackdamage { get; init; }
        public double Attackdamageperlevel { get; init; }
        public double Attackspeedperlevel { get; init; }
        public double Attackspeed { get; init; }
    }
}
