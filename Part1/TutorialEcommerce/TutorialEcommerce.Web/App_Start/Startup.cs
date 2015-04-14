using Microsoft.Owin;
using Owin;
using TutorialEcommerce.Web.App_Start;

[assembly: OwinStartup(typeof(Startup))]

namespace TutorialEcommerce.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
