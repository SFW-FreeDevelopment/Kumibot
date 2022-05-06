using System.Text.Json.Serialization;

namespace Kumibot.App.Models.SportRadar;

public class Rankings
{
    public class Competitor
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonPropertyName("age_group")]
        public string AgeGroup { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("qualifier")]
        public string Qualifier { get; set; }

        [JsonPropertyName("virtual")]
        public bool Virtual { get; set; }
    }

    public class CompetitorRanking
    {
        [JsonPropertyName("competitor")]
        public Competitor Competitor { get; set; }

        [JsonPropertyName("movement")]
        public int Movement { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }
    }

    public class Ranking
    {
        [JsonPropertyName("competitor_rankings")]
        public List<CompetitorRanking> CompetitorRankings { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }

        [JsonPropertyName("week")]
        public int Week { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("generated_at")]
        public DateTime GeneratedAt { get; set; }

        [JsonPropertyName("rankings")]
        public List<Ranking> Rankings { get; set; }
    }
}