using System.Text.Json.Serialization;

namespace Kumibot.App.Models.SportRadar;

public class CompetitorMergeMappings
{
    public class Mapping
    {
        [JsonPropertyName("merged_id")]
        public string MergedId { get; set; }

        [JsonPropertyName("retained_id")]
        public string RetainedId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("generated_at")]
        public DateTime GeneratedAt { get; set; }

        [JsonPropertyName("mappings")]
        public List<Mapping> Mappings { get; set; }
    }


}