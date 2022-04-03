using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using RoboApi.Model;
using RoboApi.Service;

namespace RoboApi
{
    public class Program
    {
        static readonly HttpClient postVoo = new HttpClient();
        public static void Main(string[] args)
        {
            //CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
            string opc;
            do
            {
                Menu();
                opc = Console.ReadLine();

                switch (opc)
                {
                    case "1":
                        RunAsync().Wait();
                        break;
                    case "2":
                        RelatorioPrecoBase.ArquivoXmlPrecoBase();
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!!");
                        break;
                }

            } while (opc != "0");
            Menu();

            
        }
        public static void Menu()
        {
            Console.WriteLine("-----------------------------------------------\n" +
                              "[1] - Executar Robô\n" +
                              "[2] - Arquivo Json - Preço Base\n" +
                              "[3] - Arquivo Json - Passagem Compradas no mês\n" +
                              "-----------------------------------------------");
            Console.Write("Opção: ");
        }

        public static async Task RunAsync()
        {
            Console.WriteLine("Extraindo e adicionando dados...");

            string pathFile = @"C:\5by5\WillFly\voo.json";
            var voo = ReadFile.GetDataVoo(pathFile);
            try
            {
                postVoo.BaseAddress = new Uri("https://localhost:44367/");
                postVoo.DefaultRequestHeaders.Accept.Clear();
                postVoo.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await postVoo.GetAsync("api/Voos");
                response.EnsureSuccessStatusCode();
                voo.ForEach(p => postVoo.PostAsJsonAsync("api/Voos", p));

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async static Task AdicionarPassageiro(List<Passageiro> passageiro)
        {
            foreach (var add in passageiro)
                await WillFlyAddApi.CadastroPassageiro(add);
        }
    }
}
