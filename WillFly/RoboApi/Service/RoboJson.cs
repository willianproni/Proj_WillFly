using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RoboApi.Service
{
    public class RoboJson
    {
        public static readonly HttpClient ApiWillFly = new HttpClient();
        public static async Task AdicionandoInformacoesJsonNaApiVoo()
        {
            Console.WriteLine("Extraindo e adicionando dados...");

            string pathFile = @"C:\5by5\WillFly\voo.json";
            var voo = ReadFile.GetDataVoo(pathFile);
            try
            {
                ApiWillFly.BaseAddress = new Uri("https://localhost:44367/");
                ApiWillFly.DefaultRequestHeaders.Accept.Clear();
                ApiWillFly.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await ApiWillFly.GetAsync("api/Voos");
                response.EnsureSuccessStatusCode();
                voo.ForEach(p => ApiWillFly.PostAsJsonAsync("api/Voos", p));

                Console.WriteLine("Dados adicionados!!..");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
