using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RoboApi.Model;
using System.IO;

namespace RoboApi.Service
{
    public static class RelatorioApi
    {
        public static readonly HttpClient BuscaApi = new HttpClient();

        public static async void ReadJsonApiPriceBase()
        {
            try
            {
                HttpResponseMessage response = await BuscaApi.GetAsync("https://localhost:44367/api/PrecoBases");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                File.WriteAllText(@"C:\5by5\WillFly\relatorio\relatorioPrecoBase.json", responseBody);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static async void ReadJsonPassagem()
        {
            try
            {
                HttpResponseMessage response = await BuscaApi.GetAsync("https://localhost:44367/api/Passagems");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                File.WriteAllText(@"C:\5by5\WillFly\relatorio\relatoriopassagens.json", responseBody);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
