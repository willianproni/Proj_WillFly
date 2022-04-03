using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WillFly.Model
{
    public class PrecoBase
    {
        public int Id { get; set; }
        public Voo Voo { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal  Valor { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorTotal => (Valor - ((decimal)PromocaoPorcentagem / 100) * Valor); 
        public double PromocaoPorcentagem { get; set; }
        public Classe Classe { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}
