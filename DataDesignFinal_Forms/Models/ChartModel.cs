using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDesignFinal_Forms.Models
{
    internal class ChartModel
    {
        //Always a string
        [JsonProperty("X")]
        public string X { get; set; }

        //Always Boss Count
        [JsonProperty("Y")]
        public int Y { get; set; }
    }
}
