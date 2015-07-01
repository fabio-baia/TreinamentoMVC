using Ninject.Modules;
using Treinamento.Core.Model.Repository;
using Treinamento.Core.Model.Repository.Interface;

namespace Treinamento.Core.InversionControl.Modules
{
    public class RepositoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPessoaRepository>().To<PessoaRepository>();
            Bind<ICidadeRepository>().To<CidadeRepository>();
        }
    }
}