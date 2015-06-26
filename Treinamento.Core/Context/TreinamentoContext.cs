using System.Data.Entity;
using Treinamento.Core.Model;

namespace Treinamento.Core.Context
{
    public class TreinamentoContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
