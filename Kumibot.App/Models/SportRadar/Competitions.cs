using System.Text.Json.Serialization;

namespace Kumibot.App.Models.SportRadar;

public class Competitions
{
    public class Category
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }
    }

    public class Competition
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("category")]
        public Category Category { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("parent_id")]
        public string ParentId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("competitions")]
        public List<Competition> Competitions { get; set; }

        [JsonPropertyName("generated_at")]
        public DateTime GeneratedAt { get; set; }
    }
}