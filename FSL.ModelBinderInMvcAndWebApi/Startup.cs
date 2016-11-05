using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FSL.ModelBinderInMvcAndWebApi.Startup))]
namespace FSL.ModelBinderInMvcAndWebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
