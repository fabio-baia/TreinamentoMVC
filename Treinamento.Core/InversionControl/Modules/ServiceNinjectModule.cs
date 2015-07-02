using Ninject.Modules;
using Treinamento.Core.Service;
using Treinamento.Core.Service.Interfaces;

namespace Treinamento.Core.InversionControl.Modules
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPessoaService>().To<PessoaService>();
            Bind<ICidadeService>().To<CidadeService>();
            Bind<ITelefoneService>().To<TelefoneService>();
        }
    }
}