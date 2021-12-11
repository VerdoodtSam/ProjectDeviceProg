using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using ProjectSamVerdoodt.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

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
                    try {
                        string json = await client.GetStringAsync(url);
                        if (json != null)
                        {
                            if (json.Substring(0, 11).Contains("error"))
                            {
                                return null;
                            }
                            else
                            {
                                json = json.Replace(json.Substring(0, 11), json.Substring(0, 2));
                                json = json.Remove(json.Length - 3, 2);

                                List<YuGiOhCard> cards = new List<YuGiOhCard>();
                                YuGiOhCard card = JsonConvert.DeserializeObject<YuGiOhCard>(json);
                                cards.Add(card);
                                return cards;
                            }

                        }
                        else
                        {
                            return null;
                        }
                    }catch(Exception ex)
                    {
                        List<YuGiOhCard> cards = new List<YuGiOhCard>();
                        cards.Add(null);
                        return cards;
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

        public async static Task<List<YuGiOhSet>> GetYuGiOhSetsAsync()
        {
            try
            {

                using (HttpClient client = await GetClient())
                {
                    string url = _BASEURI + "/api/v7/cardsets.php";
                    string json = await client.GetStringAsync(url);
                    if (json != null)
                    {
                        YuGiOhSet set = JsonConvert.DeserializeObject<YuGiOhSet>(json);
                        List<YuGiOhSet> sets = new List<YuGiOhSet>();
                        sets.Add(set);
                        return sets;
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
    }

}

