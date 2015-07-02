using System.Linq;
using Treinamento.Core.Model;
using Treinamento.Core.Model.Repository.Interface;
using Treinamento.Core.Service.Common;
using Treinamento.Core.Service.Interfaces;

namespace Treinamento.Core.Service
{
    public class CidadeService : Service<Cidade>, ICidadeService
    {
        public CidadeService(ICidadeRepository repository)
            : base(repository)
        {
        }

        public IQueryable<string> ListarEstados()
        {
            return All().GroupBy(q => q.Uf).Select(q => q.Key);
        }
    }
}
