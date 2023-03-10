using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhanTriVi_2011063105_buoi5.Startup))]
namespace PhanTriVi_2011063105_buoi5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
