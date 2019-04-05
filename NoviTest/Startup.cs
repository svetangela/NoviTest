using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NoviTest.Startup))]
namespace NoviTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
