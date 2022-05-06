namespace Kumibot.App.Models.SportRadar;

public class CompetitorSummaries
{
    public class Channel
    {
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class Competitor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string AgeGroup { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Gender { get; set; }
        public string Qualifier { get; set; }
        public bool Virtual { get; set; }
        public Statistics Statistics { get; set; }
    }

    public class SportEventProperties
    {
        public string Value { get; set; }
    }

    public class Coverage
    {
        public bool Live { get; set; }
        public SportEventProperties SportEventProperties { get; set; }
        public string Type { get; set; }
    }

    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
    }

    public class Competition
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string ParentId { get; set; }
        public string Type { get; set; }
    }

    public class Season
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Year { get; set; }
        public string CompetitionId { get; set; }
        public bool Disabled { get; set; }
    }

    public class Id
    {
        public string Value { get; set; }
    }

    public class Name
    {
        public string Value { get; set; }
    }

    public class Sport
    {
        public Id Id { get; set; }
        public Name Name { get; set; }
    }

    public class Phase
    {
        public string Value { get; set; }
    }

    public class Type
    {
        public string Value { get; set; }
    }

    public class Stage
    {
        public Phase Phase { get; set; }
        public Type Type { get; set; }
    }

    public class SportEventContext
    {
        public Category Category { get; set; }
        public Competition Competition { get; set; }
        public Season Season { get; set; }
        public Sport Sport { get; set; }
        public Stage Stage { get; set; }
    }

    public class Venue
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public bool Changed { get; set; }
        public string CityName { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string MapCoordinates { get; set; }
        public bool ReducedCapacity { get; set; }
        public int ReducedCapacityMax { get; set; }
        public string State { get; set; }
    }

    public class SportEvent
    {
        public string Id { get; set; }
        public DateTime StartTime { get; set; }
        public bool StartTimeConfirmed { get; set; }
        public List<Channel> Channels { get; set; }
        public List<Competitor> Competitors { get; set; }
        public Coverage Coverage { get; set; }
        public string ReplacedBy { get; set; }
        public DateTime ResumeTime { get; set; }
        public SportEventContext SportEventContext { get; set; }
        public Venue Venue { get; set; }
    }

    public class SportEventStatus
    {
        public string Status { get; set; }
        public string EndPosition { get; set; }
        public string EndStrike { get; set; }
        public string EndTarget { get; set; }
        public int FinalRound { get; set; }
        public string FinalRoundLength { get; set; }
        public string MatchStatus { get; set; }
        public string Method { get; set; }
        public int ScheduledLength { get; set; }
        public bool ScoutAbandoned { get; set; }
        public string Submission { get; set; }
        public bool TitleFight { get; set; }
        public string WeightClass { get; set; }
        public string Winner { get; set; }
        public string WinnerId { get; set; }
    }

    public class Control
    {
        public string Value { get; set; }
    }

    public class Knockdowns
    {
        public string Value { get; set; }
    }

    public class SignificantStrikePercentage
    {
        public string Value { get; set; }
    }

    public class SignificantStrikes
    {
        public string Value { get; set; }
    }

    public class SignificantStrikesAttempted
    {
        public string Value { get; set; }
    }

    public class SubmissionAttempts
    {
        public string Value { get; set; }
    }

    public class TakedownPercentage
    {
        public string Value { get; set; }
    }

    public class Takedowns
    {
        public string Value { get; set; }
    }

    public class TakedownsAttempted
    {
        public string Value { get; set; }
    }

    public class TotalStrikePercentage
    {
        public string Value { get; set; }
    }

    public class TotalStrikes
    {
        public string Value { get; set; }
    }

    public class TotalStrikesAttempted
    {
        public string Value { get; set; }
    }

    public class Statistics
    {
        public Control Control { get; set; }
        public Knockdowns Knockdowns { get; set; }
        public SignificantStrikePercentage SignificantStrikePercentage { get; set; }
        public SignificantStrikes SignificantStrikes { get; set; }
        public SignificantStrikesAttempted SignificantStrikesAttempted { get; set; }
        public SubmissionAttempts SubmissionAttempts { get; set; }
        public TakedownPercentage TakedownPercentage { get; set; }
        public Takedowns Takedowns { get; set; }
        public TakedownsAttempted TakedownsAttempted { get; set; }
        public TotalStrikePercentage TotalStrikePercentage { get; set; }
        public TotalStrikes TotalStrikes { get; set; }
        public TotalStrikesAttempted TotalStrikesAttempted { get; set; }
        public List<Period> Periods { get; set; }
        public Totals Totals { get; set; }
    }

    public class Period
    {
        public List<Competitor> Competitors { get; set; }
        public int Number { get; set; }
    }

    public class Totals
    {
        public List<Competitor> Competitors { get; set; }
    }

    public class Summary
    {
        public SportEvent SportEvent { get; set; }
        public SportEventStatus SportEventStatus { get; set; }
        public Statistics Statistics { get; set; }
    }

    public class Root
    {
        public DateTime GeneratedAt { get; set; }
        public List<Summary> Summaries { get; set; }
    }
}