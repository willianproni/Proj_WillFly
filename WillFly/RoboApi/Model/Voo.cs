using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RoboApi.Model
{
    public class Voo
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("horarioembarque")]
        public DateTime HorarioEmbarque { get; set; }
        [JsonProperty("horariodesembarque")]
        public DateTime HorarioDesembarque { get; set; }
        [JsonProperty("origem")]
        public virtual Aeroporto Origem { get; set; }
        [JsonProperty("destino")]
        public virtual Aeroporto Destino { get; set; }
        [JsonProperty("aeronave")]
        public virtual Aeronave Aeronave { get; set; }
    }
}
