using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RoboApi.Model
{
    public class Passagem
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("compra")]
        public PrecoBase Compra { get; set; }
        [JsonProperty("passageiro")]
        public Passageiro Passageiro { get; set; }
        [JsonProperty("datacadastro")]
        public DateTime DataCadastro { get; set; }
    }
}
