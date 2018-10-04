using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Workflow_MVC_1.Startup))]
namespace Workflow_MVC_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
