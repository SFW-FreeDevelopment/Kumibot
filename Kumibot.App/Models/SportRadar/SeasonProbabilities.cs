using System.Text.Json.Serialization;

namespace Kumibot.App.Models.SportRadar;

public class SeasonProbabilities
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

    public class Channel
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
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

    public class Coverage
    {
        [JsonPropertyName("live")]
        public bool Live { get; set; }

        [JsonPropertyName("sport_event_properties")]
        public SportEventProperties SportEventProperties { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class Id
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class Market
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("outcomes")]
        public List<Outcome> Outcomes { get; set; }

        [JsonPropertyName("away_score")]
        public int AwayScore { get; set; }

        [JsonPropertyName("home_score")]
        public int HomeScore { get; set; }

        [JsonPropertyName("last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonPropertyName("live")]
        public bool Live { get; set; }

        [JsonPropertyName("match_time")]
        public string MatchTime { get; set; }

        [JsonPropertyName("remaining_time")]
        public string RemainingTime { get; set; }

        [JsonPropertyName("remaining_time_in_period")]
        public string RemainingTimeInPeriod { get; set; }
    }

    public class Name
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class Outcome
    {
        [JsonPropertyName("name")]
        public Name Name { get; set; }

        [JsonPropertyName("probability")]
        public Probability Probability { get; set; }
    }

    public class Phase
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class Probability
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("generated_at")]
        public DateTime GeneratedAt { get; set; }

        [JsonPropertyName("sport_event_probabilities")]
        public List<SportEventProbability> SportEventProbabilities { get; set; }
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

        [JsonPropertyName("disabled")]
        public bool Disabled { get; set; }
    }

    public class Sport
    {
        [JsonPropertyName("id")]
        public Id Id { get; set; }

        [JsonPropertyName("name")]
        public Name Name { get; set; }
    }

    public class SportEvent
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("start_time")]
        public DateTime StartTime { get; set; }

        [JsonPropertyName("start_time_confirmed")]
        public bool StartTimeConfirmed { get; set; }

        [JsonPropertyName("channels")]
        public List<Channel> Channels { get; set; }

        [JsonPropertyName("competitors")]
        public List<Competitor> Competitors { get; set; }

        [JsonPropertyName("coverage")]
        public Coverage Coverage { get; set; }

        [JsonPropertyName("replaced_by")]
        public string ReplacedBy { get; set; }

        [JsonPropertyName("resume_time")]
        public DateTime ResumeTime { get; set; }

        [JsonPropertyName("sport_event_context")]
        public SportEventContext SportEventContext { get; set; }

        [JsonPropertyName("venue")]
        public Venue Venue { get; set; }
    }

    public class SportEventContext
    {
        [JsonPropertyName("category")]
        public Category Category { get; set; }

        [JsonPropertyName("competition")]
        public Competition Competition { get; set; }

        [JsonPropertyName("season")]
        public Season Season { get; set; }

        [JsonPropertyName("sport")]
        public Sport Sport { get; set; }

        [JsonPropertyName("stage")]
        public Stage Stage { get; set; }
    }

    public class SportEventProbability
    {
        [JsonPropertyName("markets")]
        public List<Market> Markets { get; set; }

        [JsonPropertyName("sport_event")]
        public SportEvent SportEvent { get; set; }

        [JsonPropertyName("sport_event_status")]
        public SportEventStatus SportEventStatus { get; set; }
    }

    public class SportEventProperties
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class SportEventStatus
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("end_position")]
        public string EndPosition { get; set; }

        [JsonPropertyName("end_strike")]
        public string EndStrike { get; set; }

        [JsonPropertyName("end_target")]
        public string EndTarget { get; set; }

        [JsonPropertyName("final_round")]
        public int FinalRound { get; set; }

        [JsonPropertyName("final_round_length")]
        public string FinalRoundLength { get; set; }

        [JsonPropertyName("match_status")]
        public string MatchStatus { get; set; }

        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("scheduled_length")]
        public int ScheduledLength { get; set; }

        [JsonPropertyName("scout_abandoned")]
        public bool ScoutAbandoned { get; set; }

        [JsonPropertyName("submission")]
        public string Submission { get; set; }

        [JsonPropertyName("title_fight")]
        public bool TitleFight { get; set; }

        [JsonPropertyName("weight_class")]
        public string WeightClass { get; set; }

        [JsonPropertyName("winner")]
        public string Winner { get; set; }

        [JsonPropertyName("winner_id")]
        public string WinnerId { get; set; }
    }

    public class Stage
    {
        [JsonPropertyName("phase")]
        public Phase Phase { get; set; }

        [JsonPropertyName("type")]
        public Type Type { get; set; }
    }

    public class Type
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }
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