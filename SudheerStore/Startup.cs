using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SudheerStore.Startup))]
namespace SudheerStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
