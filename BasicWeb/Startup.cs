using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BasicWeb.Startup))]
namespace BasicWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
