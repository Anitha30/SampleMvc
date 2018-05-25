using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleMvcFriend.Startup))]
namespace SampleMvcFriend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
