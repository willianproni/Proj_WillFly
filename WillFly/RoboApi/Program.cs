using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using RoboApi.Model;
using RoboApi.Service;

namespace RoboApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
            RunAsync().Wait();
        }

        public static async Task RunAsync()
        {
            Console.WriteLine("Extraindo e adicionando dados...");

            var pathFile = @"C:\5by5\WillFly\passageiro.json";
            await AdicionarPassageiro(ReadFile.ExtrairDados(pathFile));

            Console.WriteLine("Adicionado com sucesso");
        }

        public async static Task AdicionarPassageiro(List<Passageiro> passageiro)
        {
            foreach (var add in passageiro)
                await WillFlyAddApi.CadastroPassageiro(add);
        }
    }
}
