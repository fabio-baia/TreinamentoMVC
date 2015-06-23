using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Treinamento.Models
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [UIHint("Albums")]
        public virtual ICollection<Album> Albums { get; set; }
    }
}