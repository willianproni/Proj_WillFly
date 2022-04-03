using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RoboApi.Model
{
    public class PrecoBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("voo")]
        public Voo Voo { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [JsonProperty("valor")]
        public decimal Valor { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [JsonProperty("valortotal")]
        public decimal ValorTotal => (Valor - ((decimal)PromocaoPorcentagem / 100) * Valor);
        [JsonProperty("promocaoporcentagem")]
        public double PromocaoPorcentagem { get; set; }
        [JsonProperty("classe")]
        public Classe Classe { get; set; }
        [JsonProperty("datainclusao")]
        public DateTime DataInclusao { get; set; }
    }
}
