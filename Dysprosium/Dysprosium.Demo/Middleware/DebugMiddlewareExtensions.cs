using Dysprosium.Demo.Middleware;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Namespace the same as for IAppBuilder!!!
// Makes it simpler to use.
namespace Owin
{
    public static class DebugMiddlewareExtensions
    {
        public static void UseDebugMiddleware(this IAppBuilder app, DebugMiddlewareOptions options = null)
        {
            if (options == null)
                options = new DebugMiddlewareOptions();
            app.Use<DebugMiddleware>(options);
        }
    }
}