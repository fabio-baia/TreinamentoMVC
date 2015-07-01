using System.Linq;
using Treinamento.Core.Model;
using Treinamento.Core.Service.Common;

namespace Treinamento.Core.Service.Interfaces
{
    public interface ICidadeService : IService<Cidade>
    {
        IQueryable<string> ListarEstados();
    }
}