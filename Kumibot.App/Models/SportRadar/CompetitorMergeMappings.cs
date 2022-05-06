namespace Kumibot.App.Models.SportRadar;

public class CompetitorMergeMappings
{
    public class Mapping
    {
        public string MergedId { get; set; }
        public string RetainedId { get; set; }
        public string Name { get; set; }
    }

    public class Root
    {
        public DateTime GeneratedAt { get; set; }
        public List<Mapping> Mappings { get; set; }
    }
}