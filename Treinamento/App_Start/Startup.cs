using Microsoft.Owin;
using Owin;
using Treinamento;

[assembly:OwinStartup(typeof(Startup))]
namespace Treinamento
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}