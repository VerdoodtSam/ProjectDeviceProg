using Newtonsoft.Json;

namespace ProjectSamVerdoodt.Models
{
    public class YuGiOhSet
    {
        [JsonProperty(PropertyName = "set_name")]
        public string SetName { get; set; }
    }
}
