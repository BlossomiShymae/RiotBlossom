﻿namespace BlossomiShymae.Gwen.Dto.Riot.LolChallenges
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record ChallengePoints
    {
        public string Level { get; init; } = default!;
        public double Current { get; init; }
        public double Max { get; init; }
        public double Percentile { get; init; }
    }
}