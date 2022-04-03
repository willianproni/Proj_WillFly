using System;

namespace WillFly.Model
{
    public class Voo
    {
        public int  Id { get; set; }
        public DateTime HorarioEmbarque { get; set; }
        public DateTime HorarioDesembarque { get; set; }
        public virtual Aeroporto Origem { get; set; }
        public virtual Aeroporto Destino { get; set; }
        public virtual Aeronave Aeronave { get; set; }
    }
}
