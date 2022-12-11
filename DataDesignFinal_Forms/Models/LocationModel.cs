using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDesignFinal_Forms.Models
{
    internal class LocationModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }
    }
}
