using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewOnlineNoticeBoard.Startup))]
namespace NewOnlineNoticeBoard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
