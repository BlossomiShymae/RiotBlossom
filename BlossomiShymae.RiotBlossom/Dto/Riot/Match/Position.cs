namespace BlossomiShymae.RiotBlossom.Dto.Riot.Match
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Position : DataObject<Position>
    {
        public double X { get; init; }
        public double Y { get; init; }
    }
}
