using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bullet_Journal_5.Startup))]
namespace Bullet_Journal_5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
