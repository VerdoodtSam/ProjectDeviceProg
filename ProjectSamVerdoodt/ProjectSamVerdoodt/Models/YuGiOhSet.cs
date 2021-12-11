using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectSamVerdoodt.Models
{
    public class YuGiOhSet
    {
        [JsonProperty(PropertyName = "set_name")]
        public string SetName { get; set; }
    }
}
