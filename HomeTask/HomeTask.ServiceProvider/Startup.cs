using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeTask.ServiceProvider.Startup))]
namespace HomeTask.ServiceProvider
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
