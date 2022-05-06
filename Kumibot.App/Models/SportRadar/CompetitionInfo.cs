namespace Kumibot.App.Models.SportRadar;

public class CompetitionInfo
{
    public class Child
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string ParentId { get; set; }
        public string Type { get; set; }
    }

    public class Competition
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Child> Children { get; set; }
        public string Gender { get; set; }
        public string ParentId { get; set; }
        public string Type { get; set; }
    }

    public class Info
    {
        public string CompetitionStatus { get; set; }
        public bool VenueReducedCapacity { get; set; }
        public int VenueReducedCapacityMax { get; set; }
    }

    public class Root
    {
        public Competition Competition { get; set; }
        public DateTime GeneratedAt { get; set; }
        public Info Info { get; set; }
    }
}