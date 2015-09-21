using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AA.UI.District.Startup))]
namespace AA.UI.District
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
