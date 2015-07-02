using Treinamento.Core.Model;
using Treinamento.Core.Model.Repository.Interface;
using Treinamento.Core.Service.Common;
using Treinamento.Core.Service.Interfaces;

namespace Treinamento.Core.Service
{
    public class PessoaService : Service<Pessoa>, IPessoaService
    {
        public PessoaService(IPessoaRepository repository)
            : base(repository)
        {
        }
    }
}
