using System.Text.Json.Serialization;

namespace Kumibot.App.Models.SportRadar;

public class SeasonInfo
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

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("parent_id")]
        public string ParentId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

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
        [JsonPropertyName("competition_status")]
        public string CompetitionStatus { get; set; }

        [JsonPropertyName("venue_reduced_capacity")]
        public bool VenueReducedCapacity { get; set; }

        [JsonPropertyName("venue_reduced_capacity_max")]
        public int VenueReducedCapacityMax { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("competitors")]
        public List<Competitor> Competitors { get; set; }

        [JsonPropertyName("generated_at")]
        public DateTime GeneratedAt { get; set; }

        [JsonPropertyName("season")]
        public Season Season { get; set; }

        [JsonPropertyName("venue")]
        public Venue Venue { get; set; }
    }

    public class Season
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("start_date")]
        public string StartDate { get; set; }

        [JsonPropertyName("end_date")]
        public string EndDate { get; set; }

        [JsonPropertyName("year")]
        public string Year { get; set; }

        [JsonPropertyName("competition_id")]
        public string CompetitionId { get; set; }

        [JsonPropertyName("category")]
        public Category Category { get; set; }

        [JsonPropertyName("competition")]
        public Competition Competition { get; set; }

        [JsonPropertyName("disabled")]
        public bool Disabled { get; set; }

        [JsonPropertyName("info")]
        public Info Info { get; set; }

        [JsonPropertyName("sport")]
        public Sport Sport { get; set; }
    }

    public class Sport
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Venue
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("capacity")]
        public int Capacity { get; set; }

        [JsonPropertyName("changed")]
        public bool Changed { get; set; }

        [JsonPropertyName("city_name")]
        public string CityName { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("country_name")]
        public string CountryName { get; set; }

        [JsonPropertyName("map_coordinates")]
        public string MapCoordinates { get; set; }

        [JsonPropertyName("reduced_capacity")]
        public bool ReducedCapacity { get; set; }

        [JsonPropertyName("reduced_capacity_max")]
        public int ReducedCapacityMax { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }
    }
}