using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RoboApi.Model
{
    public class Endereco
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("cep")]
        public string Cep { get; set; }
        [JsonProperty("localidade")]
        public string Localidade { get; set; }
        [JsonProperty("uf")]
        public string Uf { get; set; }
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }
        [JsonProperty("bairro")]
        public string Bairro { get; set; }
        [JsonProperty("complemento")]
        public string Complemento { get; set; }
        [JsonProperty("pais")]
        public string Pais { get; set; }
        [JsonProperty("numero")]
        public string Numero { get; set; }
    }
}
