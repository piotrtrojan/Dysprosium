using Nancy;
using Nancy.Owin;

namespace Dysprosium.Demo.Modules
{
    public class NancyDemoModule : NancyModule
    {
        public NancyDemoModule()
        {
            Get("/nancy", x => {
                var env = Context.GetOwinEnvironment();
                return $"Hello from Nancy! You reuqested {env["owin.RequestPath"]}";
            });
        }
    }
}