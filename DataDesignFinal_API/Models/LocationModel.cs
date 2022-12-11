using Newtonsoft.Json;

namespace DataDesignFinal_API.Models
{
    public class LocationModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }
    }
}
