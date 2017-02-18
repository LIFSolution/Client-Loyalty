using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Client_Loyalty.Startup))]
namespace Client_Loyalty
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //
            //
        }
    }
}
