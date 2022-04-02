using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WillFly.Model
{
    public class Passagem
    {
        public int Id { get; set; }
        public Voo Voo { get; set; }
        public Passageiro passageiro { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Valor { get; set; }
        public Classe Classe { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
