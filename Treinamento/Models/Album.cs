namespace Treinamento.Models
{
    public class Album
    {
        public int Id { get; set; }
        public int GeneroId { get; set; }
        public int ArtistId { get; set; }
        public string Titulo { get; set; }
        public decimal Valor { get; set; }
        public string UrlArte { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual Artista Artista { get; set; }
    }
}