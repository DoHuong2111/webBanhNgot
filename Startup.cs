using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_banh_ngot.Startup))]
namespace Web_banh_ngot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
