using System;
using System.ComponentModel.DataAnnotations;

namespace WillFly.Model
{
    public class Passageiro
    {
        [Key]
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public string Email { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
