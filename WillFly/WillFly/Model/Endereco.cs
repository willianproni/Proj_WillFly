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
        public int Numero { get; set; }
        public  string Pais { get; set; }
    }
}
