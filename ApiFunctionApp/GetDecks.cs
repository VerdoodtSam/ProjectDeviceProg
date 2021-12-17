using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ApiFunctionApp
{
    public static class GetDecks
    {
        [FunctionName("GetDecks")]
        public static async Task<IActionResult> getdecks(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get",  Route = "decks")] HttpRequest req,
            ILogger log)
        {
            try
            {
                Dictionary<string, List<string>> jsondeck = new Dictionary<string, List<string>>();
                List<string> decks = new List<string>();

                string connectionString = Environment.GetEnvironmentVariable("ConnectionString");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        string sql = "SELECT DISTINCT DeckName FROM Deck";
                        command.CommandText = sql;

                        SqlDataReader reader = await command.ExecuteReaderAsync();
                        while (reader.Read())
                        {
                            decks.Add((reader["DeckName"].ToString()).TrimEnd());
                        }
                    }
                }
                jsondeck.Add("Decks", decks);
                return new OkObjectResult(jsondeck);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                log.LogError(ex.Message);
                return new StatusCodeResult(500);
            }
            
        }
    }
}
