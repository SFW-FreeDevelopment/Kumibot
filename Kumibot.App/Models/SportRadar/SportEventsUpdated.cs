using System.Text.Json.Serialization;

namespace Kumibot.App.Models.SportRadar;

public class SportEventsUpdated
{
    public class Root
    {
        [JsonPropertyName("generated_at")]
        public DateTime GeneratedAt { get; set; }

        [JsonPropertyName("sport_events_updated")]
        public List<SportEventUpdated> SportEventsUpdated { get; set; }
    }

    public class SportEventUpdated
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}