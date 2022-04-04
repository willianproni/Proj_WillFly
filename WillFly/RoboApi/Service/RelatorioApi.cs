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
                //File.WriteAllText(@"C:\5by5\WillFly\relatorio\relatorioPrecoBase.json", responseBody);

                var precobase = JsonConvert.DeserializeObject<List<PrecoBase>>(responseBody);

                var precoBaseLinq =
                    (from dados in precobase
                     orderby dados.DataInclusao descending
                     select dados
                    );

                var precoBaseJson = JsonConvert.SerializeObject(precoBaseLinq, Formatting.Indented);
                File.WriteAllText(@"C:\5by5\WillFly\relatorio\relatorioprecobasemes.json", precoBaseJson);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static async void ReadJsonPassagem(int mes)
        {
            try
            {
                HttpResponseMessage response = await BuscaApi.GetAsync("https://localhost:44367/api/Passagems");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                //File.WriteAllText(@"C:\5by5\WillFly\relatorio\relatoriopassagens.json", responseBody);

                var passagem = JsonConvert.DeserializeObject<List<Passagem>>(responseBody);

                var passagemLinq = (
                    from dados in passagem
                    where dados.DataCadastro.Month.Equals(mes)
                    select dados);

                var passagemJson = JsonConvert.SerializeObject(passagemLinq, Formatting.Indented);
                File.WriteAllText(@"C:\5by5\WillFly\relatorio\relatoriopassagens.json", passagemJson);
            }

            catch (Exception)
            {

                throw;
            }
        }
    }
}
