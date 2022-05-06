namespace Kumibot.App.Models.SportRadar;

public class Competitions
{
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
        public Category Category { get; set; }
        public string Gender { get; set; }
        public string ParentId { get; set; }
        public string Type { get; set; }
    }

    public class Root
    {
        public List<Competition> Competitions { get; set; }
        public DateTime GeneratedAt { get; set; }
    }
}