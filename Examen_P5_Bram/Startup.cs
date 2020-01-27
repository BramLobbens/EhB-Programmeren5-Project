using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Examen_P5_Bram.Startup))]
namespace Examen_P5_Bram
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
