using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Treinamento.Models
{
    public class Album
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("GeneroId")]
        public int GeneroId { get; set; }
        
        [DisplayName("ArtistId")]
        public int ArtistId { get; set; }
        
        [DisplayName("Titulo")]
        [StringLength(20, ErrorMessage = "20 caracteres é o máximo permitido")]
        [Required(ErrorMessage = "O título é obrigatório")]
        [DataType(DataType.Text)]
        public string Titulo { get; set; }
        
        [DisplayName("Valor")]
        public decimal Valor { get; set; }
        
        [DisplayName("UrlArte")]
        public string UrlArte { get; set; }
        
        [DisplayName("Genero")]
        public virtual Genero Genero { get; set; }
        
        [DisplayName("Artista")]
        public virtual Artista Artista { get; set; }
    }
}