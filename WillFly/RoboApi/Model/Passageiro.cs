using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RoboApi.Model
{
    public class Passageiro
    {
        [JsonProperty("cpf")]
        public  string Cpf { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("telefone")]
        public string Telefone { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("endereco")]
        public Endereco Endereco { get; set; }
    }
}
