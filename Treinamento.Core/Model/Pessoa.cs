using System.ComponentModel.DataAnnotations.Schema;

namespace Treinamento.Core.Model
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int IdCidade { get; set; }

        [ForeignKey("IdCidade")]
        public virtual Cidade Cidade { get; set; }
    }
}
