using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bier.Startup))]
namespace Bier
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
