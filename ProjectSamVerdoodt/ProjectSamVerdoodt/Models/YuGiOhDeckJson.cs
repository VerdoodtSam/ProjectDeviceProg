using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProjectSamVerdoodt.Models
{
    public class YuGiOhDeckJson
    {
        [JsonProperty(PropertyName = "Decks")]
        public List<string> DeckList { get; set; }
    }
}
