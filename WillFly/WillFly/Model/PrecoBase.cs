using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WillFly.Model
{
    public class PrecoBase
    {
        public int Id { get; set; }
     
        public Aeroporto Origem { get; set; }
   
        public Aeroporto Destino { get; set; }
        [Column(TypeName ="decimal(10, 2)")]
        public decimal Valor { get; set; }
        public double PromocaoPocentagem { get; set; }
        public Classe Classe { get; set; }
   
        public DateTime DataInclusao { get; set; }
    }
}
