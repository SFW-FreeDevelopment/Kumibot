using System.Text.Json.Serialization;

namespace Kumibot.App.Models.SportRadar;

public class CompetitionInfo
{
    public class Child
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("parent_id")]
        public string ParentId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class Competition
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("children")]
        public List<Child> Children { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("parent_id")]
        public string ParentId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class Info
    {
        [JsonPropertyName("competition_status")]
        public string CompetitionStatus { get; set; }

        [JsonPropertyName("venue_reduced_capacity")]
        public bool VenueReducedCapacity { get; set; }

        [JsonPropertyName("venue_reduced_capacity_max")]
        public int VenueReducedCapacityMax { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("competition")]
        public Competition Competition { get; set; }

        [JsonPropertyName("generated_at")]
        public DateTime GeneratedAt { get; set; }

        [JsonPropertyName("info")]
        public Info Info { get; set; }
    }
}