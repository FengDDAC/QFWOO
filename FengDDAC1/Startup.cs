using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FengDDAC1.Startup))]
namespace FengDDAC1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
