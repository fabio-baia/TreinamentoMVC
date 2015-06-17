using System.Data.Entity;
using Treinamento.Models;

namespace Treinamento.Context.Initializer
{
    public class LojaInitializer : DropCreateDatabaseAlways<LojaContext>
    {
        protected override void Seed(LojaContext context)
        {
            context.Artistas.Add(new Artista(){ Nome = "Hugh Laurie" });
            context.Generos.Add(new Genero(){ Nome = "Blues" });
            context.Albums.Add(new Album()
            {
                Artista = new Artista() { Nome = "Linkin Park"},
                Genero = new Genero() { Nome = "Rock"},
                Valor = 9.99m,
                Titulo = "Rock, Rock, Rock"
            });

            base.Seed(context);
        }
    }
}