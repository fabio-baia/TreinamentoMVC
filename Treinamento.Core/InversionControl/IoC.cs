using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using Treinamento.Core.InversionControl.Modules;

namespace Treinamento.Core.InversionControl
{
    public class IoC
    {
        public IKernel Kernel { get; set; }

        public IoC()
        {
            Kernel = GetNinjectModules();
            ServiceLocator.SetLocatorProvider
            (
                () => new NinjectServiceLocator(Kernel)
            );
        }

        private IKernel GetNinjectModules()
        {
            return new StandardKernel(
                new ServiceNinjectModule(),
                new InfrastructureNinjectModule(),
                new RepositoryNinjectModule()
                );
        }
    }
}
