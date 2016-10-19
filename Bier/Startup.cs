using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Beer.Startup))]
namespace Beer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
