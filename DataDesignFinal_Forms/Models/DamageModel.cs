using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDesignFinal_Forms.Models
{
    internal class DamageModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("damageType")]
        public string DamageType { get; set; }
    }
}
