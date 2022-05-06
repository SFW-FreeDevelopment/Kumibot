using System.Text.Json.Serialization;

namespace Kumibot.App.Models.SportRadar;

public class SportEventsRemoved
{
    public class Root
    {
        [JsonPropertyName("generated_at")]
        public DateTime GeneratedAt { get; set; }

        [JsonPropertyName("sport_events_removed")]
        public List<SportEventRemoved> SportEventsRemoved { get; set; }
    }

    public class SportEventRemoved
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("replaced_by")]
        public string ReplacedBy { get; set; }
    }
}