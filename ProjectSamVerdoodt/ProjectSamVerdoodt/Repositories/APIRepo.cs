using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using ProjectSamVerdoodt.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjectSamVerdoodt.Repositories
{
    public static class APIRepo
    {

        private const string _BASEURI = "https://db.ygoprodeck.com";
  
        private static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
        public static async Task<YuGiOhCard> GetRandomCardAsync()
        {
            string url = _BASEURI + "/api/v7/randomcard.php";

            using(HttpClient client = GetClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);

                    YuGiOhCard card = JsonConvert.DeserializeObject<YuGiOhCard>(json);
                    return card;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

    }
}
