using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieTutorial.Startup))]
namespace MovieTutorial
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
