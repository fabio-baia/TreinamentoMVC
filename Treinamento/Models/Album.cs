using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;
using Treinamento.Resources;

namespace Treinamento.Models
{
    public class Album : IValidatableObject
    {
        [Display(ResourceType = typeof(AlbumResources), Name = "Id")]
        public int Id { get; set; }

        [Display(ResourceType = typeof(AlbumResources), Name = "GenreId")]
        public int GeneroId { get; set; }

        [Display(ResourceType = typeof(AlbumResources), Name = "ArtistId")]
        public int ArtistId { get; set; }
        
        [Display(ResourceType = typeof(AlbumResources), Name = "Title")]
        [StringLength(20, ErrorMessage = "20 caracteres é o máximo permitido")]
        [Required(ErrorMessage = "O título é obrigatório")]
        [DataType(DataType.Text)]
        public string Titulo { get; set; }

        [Display(ResourceType = typeof(AlbumResources), Name = "Price")]
        public decimal Valor { get; set; }
        
        //[DisplayName("UrlArte")]
        //[RegularExpression(@"^http://.*\.(png|jpg)$", ErrorMessage = "Url deve ser uma imagem .PNG ou .JPG")]
        public string UrlArte { get; set; }

        [Display(ResourceType = typeof(AlbumResources), Name = "Genre")]
        public virtual Genero Genero { get; set; }

        [Display(ResourceType = typeof(AlbumResources), Name = "Artist")]
        public virtual Artista Artista { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (UrlArte != null && UrlArte.EndsWith(".gif"))
            {
                yield return new ValidationResult("Não é suportado esse tipo de imagem", new[] { "UrlArte" });
            }
        }
    }
}