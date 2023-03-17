﻿namespace Gwen.Dto.Riot.Match
{
    public record EventDto
    {
        public int RealTimestamp { get; init; }
        public int Timestamp { get; init; }
        public string Type { get; init; } = default!;
    }
}