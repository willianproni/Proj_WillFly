using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using RoboApi.Model;

namespace RoboApi.Service
{
    public class WillFlyAddApi
    {
        public static async Task CadastroPassageiro(Passageiro passageiro)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.BaseAddress = new Uri("https://localhost:44367/");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await httpClient.PostAsJsonAsync($"api/Passageiroes", passageiro);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
