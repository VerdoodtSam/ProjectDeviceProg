using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectSamVerdoodt.Models
{
    public class YuGiOhCard
    {
        [JsonProperty(PropertyName = "id")]
        public int CardId { get; set; }

        [JsonProperty(PropertyName ="name")]
        public string CardName{ get; set; }

        [JsonProperty(PropertyName ="type")]
        public string CardType { get; set; }

        [JsonProperty(PropertyName ="desc")]
        public string CardDesc { get; set; }


        public string CardImg { get { return CalculateImg(); } }

        private string CalculateImg()
        {
            String source = "https://storage.googleapis.com/ygoprodeck.com/pics/" + this.CardId + ".jpg";
            return source;
        }
    }
}
