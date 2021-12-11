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
  
        private static async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
        public async static Task<List<YuGiOhCard>> GetCardInfo(string name)
        {
            try
            {
                using (HttpClient client = await GetClient())
                {
                    string url = _BASEURI + "/api/v7/cardinfo.php?name=" + name;
                    string json = await client.GetStringAsync(url);
                    if(json != null)
                    {
                        YuGiOhCard card = JsonConvert.DeserializeObject<YuGiOhCard>(json);
                        List<YuGiOhCard> cards = new List<YuGiOhCard>();
                        cards.Add(card);
                        return cards;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public  async static Task<List<YuGiOhCard>> GetRandomCardAsync()
        {
            try
            {

                using (HttpClient client = await GetClient())
                {
                    string url = _BASEURI + "/api/v7/randomcard.php";
                    string json = await client.GetStringAsync(url);
                    if (json != null)
                    {
                        YuGiOhCard card = JsonConvert.DeserializeObject<YuGiOhCard>(json);
                        List<YuGiOhCard> cards = new List<YuGiOhCard>();
                        cards.Add(card);
                        return cards;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }

}

