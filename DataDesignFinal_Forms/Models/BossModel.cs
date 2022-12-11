using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDesignFinal_Forms.Models
{
    internal class BossModel
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
        public string Weakness { get; set; }
    }
}
