using Treinamento.Core.Model;
using Treinamento.Core.Model.Repository.Interface;
using Treinamento.Core.Service.Common;
using Treinamento.Core.Service.Interfaces;

namespace Treinamento.Core.Service
{
    public class TelefoneService : Service<Telefone>, ITelefoneService
    {
        public TelefoneService(ITelefoneRepository repository)
            : base(repository)
        {
        }
    }
}
