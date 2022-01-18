using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CapaPresentacion.Startup))]
namespace CapaPresentacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
