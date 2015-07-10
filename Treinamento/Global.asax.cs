using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Treinamento.App_Start;
using Treinamento.Context.Initializer;
using Treinamento.Core.Context.Initializer;
using Treinamento.Instrumentation;

namespace Treinamento
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_BeginRequest()
        {
            Context.PageInstrumentation.ExecutionListeners.Add(new CustomExecutionListener());
        }

        protected void Application_Start()
        {
            Database.SetInitializer(new LojaInitializer());
            Database.SetInitializer(new TreinamentoInitializer());

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BinderConfig.Register();

            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }
    }
}