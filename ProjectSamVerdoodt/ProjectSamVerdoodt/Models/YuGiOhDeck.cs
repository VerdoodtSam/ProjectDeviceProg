using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProjectSamVerdoodt.Models
{
    public class YuGiOhDeck
    {
        [JsonProperty(PropertyName = "Card_List")]
        public List<YuGiOhDeckCard> MyProperty { get; set; }
    }
    public class YuGiOhDeckCard
    {
        [JsonProperty(PropertyName = "amount")]
        public int Card_amount { get; set; }

        [JsonProperty(PropertyName = "deckCardId")]
        public int Card_id { get; set; }
    }
}
