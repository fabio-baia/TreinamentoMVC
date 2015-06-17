using System.Data.Entity;
using Treinamento.Models;

namespace Treinamento.Context
{
    public class LojaContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Genero> Generos { get; set; }

        public LojaContext() : base("DefaultConnection")
        {

        }

    }
}