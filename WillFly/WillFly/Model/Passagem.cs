using System;

namespace WillFly.Model
{
    public class Passagem
    {
        public int Id { get; set; }
        /*public PrecoBase InfoCompra { get; set; } //Origem, Destino, Valor, Classe;*/
        public Passageiro Passageiro { get; set; }
        public DateTime DataCadastro { get; set; }
    } 
} 
