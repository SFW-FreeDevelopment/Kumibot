using System.Text.Json.Serialization;

namespace Kumibot.App.Models.SportRadar;

public class CompetitorProfile
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

    public class Info
    {
        [JsonPropertyName("birth_city")]
        public string BirthCity { get; set; }

        [JsonPropertyName("birth_country")]
        public string BirthCountry { get; set; }

        [JsonPropertyName("birth_country_code")]
        public string BirthCountryCode { get; set; }

        [JsonPropertyName("birth_date")]
        public string BirthDate { get; set; }

        [JsonPropertyName("birth_state")]
        public string BirthState { get; set; }

        [JsonPropertyName("fighting_out_of_city")]
        public string FightingOutOfCity { get; set; }

        [JsonPropertyName("fighting_out_of_country")]
        public string FightingOutOfCountry { get; set; }

        [JsonPropertyName("fighting_out_of_country_code")]
        public string FightingOutOfCountryCode { get; set; }

        [JsonPropertyName("fighting_out_of_state")]
        public string FightingOutOfState { get; set; }

        [JsonPropertyName("height")]
        public double Height { get; set; }

        [JsonPropertyName("nickname")]
        public string Nickname { get; set; }

        [JsonPropertyName("reach")]
        public int Reach { get; set; }

        [JsonPropertyName("weight")]
        public double Weight { get; set; }
    }

    public class Record
    {
        [JsonPropertyName("draws")]
        public int Draws { get; set; }

        [JsonPropertyName("losses")]
        public int Losses { get; set; }

        [JsonPropertyName("no_contests")]
        public int NoContests { get; set; }

        [JsonPropertyName("wins")]
        public int Wins { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("competitor")]
        public Competitor Competitor { get; set; }

        [JsonPropertyName("generated_at")]
        public DateTime GeneratedAt { get; set; }

        [JsonPropertyName("info")]
        public Info Info { get; set; }

        [JsonPropertyName("record")]
        public Record Record { get; set; }
    }
}