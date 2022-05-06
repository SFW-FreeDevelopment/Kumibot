namespace Kumibot.App.Models.SportRadar;

public class CompetitionSeasons
{
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

    public class Root
    {
        public DateTime GeneratedAt { get; set; }
        public List<Season> Seasons { get; set; }
    }
}