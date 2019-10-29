using Dysprosium.Demo.Middleware;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Nancy;
using Nancy.Owin;
using Owin;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Dysprosium.Demo
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.UseDebugMiddleware(new DebugMiddlewareOptions
            {
                OnIncomingRequest = (ctx) =>
                {
                    var watch = new Stopwatch();
                    watch.Start();
                    ctx.Environment["DebugStopwatch"] = watch;
                },
                OnOutgoingRequest = (ctx) =>
                {
                    var watch = (Stopwatch)ctx.Environment["DebugStopwatch"];
                    watch.Stop();
                    Debug.WriteLine($"Request took: {watch.ElapsedMilliseconds}ms.");
                }
            });

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Auth/Login")

            });

            var webApiConfig = new HttpConfiguration();
            // Scans projects for proper WebApi Attributes, ApiController inheritances etc. and registers the Controllers.
            webApiConfig.MapHttpAttributeRoutes();
            webApiConfig.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            app.UseWebApi(webApiConfig);


            // When using MVC, Nancy starts to be a problem. The simplest way is to start Nancy only for specific endpoints.
            app.Map("/nancy", mappedApp => { mappedApp.UseNancy(); });
            //app.UseNancy(nancyConfig =>
            //{
            //    nancyConfig.PassThroughWhenStatusCodesAre(HttpStatusCode.NotFound);
            //});

            // No longer can live when MVC is enabled.
            //app.Use(async (ctx, next) =>
            //{
            //    await ctx.Response.WriteAsync("<html><head></head><body><h1>Hello World!</h1></body></html>");
            //});
        }
    }
}