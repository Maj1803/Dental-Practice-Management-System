using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MTKhan_Dentist.Startup))]
namespace MTKhan_Dentist
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
