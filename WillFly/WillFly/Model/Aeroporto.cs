using System.ComponentModel.DataAnnotations;

namespace WillFly.Model
{
    public class Aeroporto
    {
        [Key]
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
