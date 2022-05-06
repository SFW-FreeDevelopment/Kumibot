using System.Text.Json.Serialization;

namespace Kumibot.App.Models.SportRadar;

public class SeasonLinks
{
    public class CupRound
    {
        [JsonPropertyName("id")]
        public Id Id { get; set; }

        [JsonPropertyName("linked_cup_rounds")]
        public LinkedCupRounds LinkedCupRounds { get; set; }

        [JsonPropertyName("name")]
        public Name Name { get; set; }

        [JsonPropertyName("sport_events")]
        public SportEvents SportEvents { get; set; }
    }

    public class Group
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("group_name")]
        public string GroupName { get; set; }

        [JsonPropertyName("cup_rounds")]
        public List<CupRound> CupRounds { get; set; }
    }

    public class Id
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class LinkedCupRounds
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class Name
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("generated_at")]
        public DateTime GeneratedAt { get; set; }

        [JsonPropertyName("stages")]
        public List<Stage> Stages { get; set; }
    }

    public class SportEvents
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class Stage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("phase")]
        public string Phase { get; set; }

        [JsonPropertyName("end_date")]
        public string EndDate { get; set; }

        [JsonPropertyName("groups")]
        public List<Group> Groups { get; set; }

        [JsonPropertyName("start_date")]
        public string StartDate { get; set; }

        [JsonPropertyName("year")]
        public string Year { get; set; }
    }
}