using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MerchEnrolServiceWebUI.Startup))]
namespace MerchEnrolServiceWebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          //  ConfigureAuth(app);
        }
    }
}
