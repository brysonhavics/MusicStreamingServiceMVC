using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicStreamingService.MVC.Startup))]
namespace MusicStreamingService.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
