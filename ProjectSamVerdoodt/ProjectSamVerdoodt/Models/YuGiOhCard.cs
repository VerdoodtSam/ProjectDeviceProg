using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ProjectSamVerdoodt.Models
{

    public class YuGiOhCard
    {
        [JsonProperty(PropertyName = "id")]
        public int CardId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string CardName { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string CardType { get; set; }

        [JsonProperty(PropertyName = "desc")]
        public string CardDesc { get; set; }

        [JsonProperty(PropertyName = "atk")]
        public int CardAtk { get; set; }

        [JsonProperty(PropertyName = "def")]
        public int CardDef { get; set; }

        [JsonProperty(PropertyName = "level")]
        public int CardLevel { get; set; }

        [JsonProperty(PropertyName = "race")]
        public string CardRace { get; set; }

        [JsonProperty(PropertyName = "attribute")]
        public string CardAttri { get; set; }

        [JsonProperty(PropertyName = "card_sets")]
        public List<YuGiOhSet> CardSet { get; set; }

        public string CardImg { get { return CalculateImg(); } }


        private string CalculateImg()
        {
            String source = "https://storage.googleapis.com/ygoprodeck.com/pics/" + this.CardId + ".jpg";
            return source;
        }
    }
}
