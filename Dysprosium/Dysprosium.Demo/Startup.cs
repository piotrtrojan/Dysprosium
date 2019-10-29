using Dysprosium.Demo.Middleware;
using Owin;
using System.Diagnostics;

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

            app.UseNancy();

            app.Use(async (ctx, next) =>
            {
                await ctx.Response.WriteAsync("<html><head></head><body><h1>Hello World!</h1></body></html>");
            });

        }
    }
}