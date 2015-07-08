using Treinamento.Core.Model;

namespace Treinamento.Testes.Factory
{
    public static class CidadeFactory
    {
        public static Cidade Create(int id, string nome, string uf)
        {
            return new Cidade{Id = id, Nome = nome, Uf = uf};
        }
    }
}