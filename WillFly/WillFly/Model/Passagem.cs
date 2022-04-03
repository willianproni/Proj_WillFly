using System;

namespace WillFly.Model
{
    public class Passagem
    {
        public int Id { get; set; }
        public PrecoBase Compra { get; set; }
        public Passageiro Passageiro { get; set; }
        public DateTime DataCadastro { get; set; }
    } 
} 
