using Newtonsoft.Json;

namespace DataDesignFinal_API.Models
{
    public class ChartModel
    {
        //Always a string
        [JsonProperty("X")]
        public string X { get; set; }

        //Always Boss Count
        [JsonProperty("Y")]
        public int Y { get; set; }
    }
}
