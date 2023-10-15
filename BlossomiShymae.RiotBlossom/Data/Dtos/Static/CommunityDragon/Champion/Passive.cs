namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.CommunityDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Passive : DataObject
    {
        public required string Name { get; init; } 
        public required string AbilityIconPath { get; init; }
        public required string AbilityVideoPath { get; init; } 
        public required string AbilityVideoImagePath { get; init; } 
        public required string Description { get; init; } 
    }
}
