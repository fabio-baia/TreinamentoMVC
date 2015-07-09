using System.Data.Entity;
using Treinamento.Core.Model;

namespace Treinamento.Core.Context
{
    public class TreinamentoContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public TreinamentoContext()
            : base("DefaultConnection")
        {

        }
    }
}
