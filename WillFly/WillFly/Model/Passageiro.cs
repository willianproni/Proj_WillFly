using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WillFly.Model
{
    public class Passageiro
    {
        [Key]
        [JsonProperty("cpf")]
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public string Email { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
