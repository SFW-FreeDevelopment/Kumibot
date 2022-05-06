using System.Text.Json.Serialization;

namespace Kumibot.App.Models.SportRadar;

public class SeasonCompetitors
{
    public class Root
    {
        [JsonPropertyName("generated_at")]
        public DateTime GeneratedAt { get; set; }

        [JsonPropertyName("season_competitors")]
        public List<SeasonCompetitor> SeasonCompetitors { get; set; }
    }

    public class SeasonCompetitor
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonPropertyName("short_name")]
        public string ShortName { get; set; }
    }
}