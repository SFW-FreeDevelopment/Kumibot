namespace Kumibot.App.Models.SportRadar;

public class CompetitorProfile
{
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
    }

    public class Info
    {
        public string BirthCity { get; set; }
        public string BirthCountry { get; set; }
        public string BirthCountryCode { get; set; }
        public string BirthDate { get; set; }
        public string BirthState { get; set; }
        public string FightingOutOfCity { get; set; }
        public string FightingOutOfCountry { get; set; }
        public string FightingOutOfCountryCode { get; set; }
        public string FightingOutOfState { get; set; }
        public double Height { get; set; }
        public string Nickname { get; set; }
        public int Reach { get; set; }
        public double Weight { get; set; }
    }

    public class Record
    {
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int NoContests { get; set; }
        public int Wins { get; set; }
    }

    public class Root
    {
        public Competitor Competitor { get; set; }
        public DateTime GeneratedAt { get; set; }
        public Info Info { get; set; }
        public Record Record { get; set; }
    }
}