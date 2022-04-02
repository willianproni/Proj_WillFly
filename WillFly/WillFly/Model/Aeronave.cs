using Newtonsoft.Json;

namespace WillFly.Model
{
    public class Aeronave
    {
        public int Id { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("capacidade")]
        public int Capacidade { get; set; }
    }
}
