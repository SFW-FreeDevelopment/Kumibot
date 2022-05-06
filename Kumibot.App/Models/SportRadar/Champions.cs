namespace Kumibot.App.Models.SportRadar;

public class Champions
{
    public class Qualifier
    {
        public string Value { get; set; }
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
        public Qualifier Qualifier { get; set; }
        public bool Virtual { get; set; }
    }

    public class WeightClass
    {
        public string Description { get; set; }
        public Competitor Competitor { get; set; }
    }

    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<WeightClass> WeightClasses { get; set; }
    }

    public class Root
    {
        public List<Category> Categories { get; set; }
        public DateTime GeneratedAt { get; set; }
    }
}