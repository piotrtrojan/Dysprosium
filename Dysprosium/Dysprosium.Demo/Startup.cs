using Dysprosium.Demo.Middleware;
using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Dysprosium.Demo
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.Use<DebugMiddleware>();

            app.Use(async (ctx, next) =>
            {
                await ctx.Response.WriteAsync("<html><head></head><body><h1>Hello World!</h1></body></html>");
            });

        }
    }
}