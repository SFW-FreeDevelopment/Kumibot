using System.Text.Json.Serialization;

namespace Kumibot.App.Models.SportRadar;

/// Generated using https://json2csharp.com/
// Check "Use Pascal Case"
// Check "Use JsonPropertyName (.NET Core)"

public class Champions
{
    public class Qualifier
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class Competitor
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonPropertyName("age_group")]
        public string AgeGroup { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("qualifier")]
        public Qualifier Qualifier { get; set; }

        [JsonPropertyName("virtual")]
        public bool Virtual { get; set; }
    }

    public class WeightClass
    {
        private string _description;
        [JsonPropertyName("description")]
        public string Description
        {
            get => _description;
            set => _description = value?.Replace("_", " ");
        }

        [JsonPropertyName("competitor")]
        public Competitor Competitor { get; set; }
    }

    public class Category
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("weight_classes")]
        public List<WeightClass> WeightClasses { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("categories")]
        public List<Category> Categories { get; set; }

        [JsonPropertyName("generated_at")]
        public DateTime GeneratedAt { get; set; }
    }
}