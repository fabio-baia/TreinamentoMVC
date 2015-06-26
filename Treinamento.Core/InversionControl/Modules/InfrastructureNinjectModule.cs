using Ninject.Modules;

namespace Treinamento.Core.InversionControl.Modules
{
    public class InfrastructureNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<Context.TreinamentoContext>().ToSelf();
        }
    }
}