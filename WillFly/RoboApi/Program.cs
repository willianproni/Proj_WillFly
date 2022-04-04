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
        public static void Main(string[] args)
        {
            string opc;
            do
            {
                Menu();
                opc = Console.ReadLine();

                switch (opc)
                {
                    case "1":
                        RoboJson.AdicionandoInformacoesJsonNaApiVoo().Wait();
                        break;
                    case "2":                   
                         RelatorioApi.ReadJsonApiPriceBase();
                        //RelatorioPrecoBase.ArquivoXmlPrecoBase(); //Arquivo XML Console Aplication
                        break;
                    case "3":
                        Console.Write("Digite o Mês da busca:");
                        int mes = int.Parse(Console.ReadLine());
                        RelatorioApi.ReadJsonPassagem(mes);
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!!");
                        break;
                }
            } while (opc != "0");
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

    }
}
