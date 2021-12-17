using Newtonsoft.Json;
using ProjectSamVerdoodt.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectSamVerdoodt.Repositories
{
    class DeckAPIRepo
    {
        private const string _BASEURI = "https://apiyugiohdeck.azurewebsites.net/api/";

        private static async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
        public async static Task<List<YuGiOhDeckJson>> GetAllDeckAsync()
        {
            try
            {
                using (HttpClient client = await GetClient())
                {
                    string url = _BASEURI + "/decks";
                    try
                    {
                        string json = await client.GetStringAsync(url);
                        if (json != null)
                        {
                            List<YuGiOhDeckJson> decks = new List<YuGiOhDeckJson>();
                            YuGiOhDeckJson deck = JsonConvert.DeserializeObject<YuGiOhDeckJson>(json);
                            decks.Add(deck);
                            return decks;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        List<YuGiOhDeckJson> decks = new List<YuGiOhDeckJson>();
                        decks.Add(null);
                        return decks;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
