using Newtonsoft.Json;

namespace DataDesignFinal_API.Models
{
    public class DamageModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("damageType")]
        public string DamageType { get; set; }
    }
}
