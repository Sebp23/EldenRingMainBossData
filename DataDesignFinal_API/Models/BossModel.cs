using Newtonsoft.Json;
namespace DataDesignFinal_API.Models
{
    public class BossModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Location")]
        public string Location { get; set; }

        [JsonProperty("Strength")]
        public string Strength { get; set; }

        [JsonProperty("Weakness")]
        public string? Weakness { get; set; }
    }
}
