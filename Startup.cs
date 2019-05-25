using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlayerSelector.Startup))]
namespace PlayerSelector
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
