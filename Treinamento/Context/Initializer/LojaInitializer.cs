using System.Data.Entity;
using Treinamento.Models;

namespace Treinamento.Context.Initializer
{
    public class LojaInitializer : DropCreateDatabaseAlways<LojaContext>
    {
        protected override void Seed(LojaContext context)
        {
            context.Artistas.Add(new Artista(){ Nome = "Rosa de Saron" });
            context.Generos.Add(new Genero(){ Nome = "Rock Cristão" });
            context.Albums.Add(new Album()
            {
                Artista = new Artista() { Nome = "Linkin Park"},
                Genero = new Genero() { Nome = "Rock"},
                Valor = 9.99m,
                Titulo = "Rock, Rock"
            });
            context.Albums.Add(new Album()
            {
                Artista = new Artista() { Nome = "Hugh Laurie" },
                Genero = new Genero() { Nome = "Blues" },
                Valor = 9.99m,
                Titulo = "Let them talk"
            });

            base.Seed(context);
        }
    }
}