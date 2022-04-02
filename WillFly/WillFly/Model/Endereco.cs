using Newtonsoft.Json;

namespace WillFly.Model
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        [JsonProperty("localidade")]
        public string Localidade { get; set; }
        [JsonProperty("uf")]
        public string Uf { get; set; }
        [JsonProperty("bairro")]
        public string Bairro { get; set; }
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }
        [JsonProperty("complemento")]
        public string Complemento { get; set; }
        [JsonProperty("numero")]
        public int Numero { get; set; }
        [JsonProperty("pais")]
        public string Pais { get; set; }

        public Endereco(string cep, string localidade, string uf, string bairro, string logradouro, string complemento)
        {
            Cep = cep;
            Localidade = localidade;
            Uf = uf;
            Bairro = bairro;
            Logradouro = logradouro;
            Complemento = complemento;
        }
    }
}
