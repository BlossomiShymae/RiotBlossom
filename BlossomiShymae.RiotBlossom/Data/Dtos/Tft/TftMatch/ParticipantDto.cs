using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Tft.TftMatch
{
    public record ParticipantDto : DataObject
    {
        /// <summary>
        /// The participant's companion.
        /// </summary>
        public required CompanionDto Companion { get; init; }
        /// <summary>
        /// The gold left after participant was eliminated.
        /// </summary>
        [JsonPropertyName("gold_left")]
        public int GoldLeft { get; init; }
        /// <summary>
        /// The round eliminated in.
        /// </summary>
        [JsonPropertyName("last_round")]
        public int LastRound { get; init; }
        /// <summary>
        /// The Little Legend level.
        /// </summary>
        public int Level { get; init; }
        /// <summary>
        /// The placement upon elimination.
        /// </summary>
        public int Placement { get; init; }
        /// <summary>
        /// The number of players eliminated.
        /// </summary>
        [JsonPropertyName("players_eliminated")]
        public int PlayersEliminated { get; init; }
        /// <summary>
        /// The encrypted PUUID of participant.
        /// </summary>
        public required string Puuid { get; init; }
        /// <summary>
        /// The number of seconds before the participant's elimination.
        /// </summary>
        [JsonPropertyName("time_eliminated")]
        public float TimeEliminated { get; init; }
        /// <summary>
        /// The damage dealt to other players.
        /// </summary>
        [JsonPropertyName("total_damage_to_players")]
        public int TotalDamageToPlayers { get; init; }
        /// <summary>
        /// The list of traits for the active units.
        /// </summary>
        public List<TraitDto> Traits { get; init; } = [];
        /// <summary>
        /// The list of active units.
        /// </summary>
        public List<UnitDto> Units { get; init; } = [];
    }
}
