using System.Data.Entity;
using Treinamento.Core.Model;

namespace Treinamento.Core.Context.Initializer
{
    public class TreinamentoInitializer : DropCreateDatabaseAlways<TreinamentoContext>
    {
        protected override void Seed(TreinamentoContext context)
        {
            context.Cidades.Add(new Cidade{ Nome = "Maringá", Uf = "PR" });
            context.Cidades.Add(new Cidade{ Nome = "Sarandi", Uf = "PR" });
            context.Cidades.Add(new Cidade{ Nome = "São Paulo", Uf = "SP" });
            context.Cidades.Add(new Cidade{ Nome = "Porto Alegre", Uf = "RS" });

            base.Seed(context);
        }
    }
}