using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AppFunc = System.Func<
    System.Collections.Generic.IDictionary<string, object>,
    System.Threading.Tasks.Task
>;

namespace Dysprosium.Demo.Middleware
{
    public class DebugMiddleware
    {
        private readonly AppFunc _next;
        private readonly DebugMiddlewareOptions _options;

        public DebugMiddleware(AppFunc next, DebugMiddlewareOptions options)
        {
            _next = next;
            _options = options;
            if (_options.OnIncomingRequest == null)
                _options.OnIncomingRequest = (ctx) => { Debug.WriteLine($"Incoming Request: {ctx.Request.Path}"); };
            
            if (_options.OnOutgoingRequest == null)
                _options.OnOutgoingRequest = (ctx) => { Debug.WriteLine($"Outgoing Request: {ctx.Request.Path}"); };
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            // To get Owin Context, just call constructor with environment parameter.
            var ctx = new OwinContext(environment);
            // Just for example - how to get environment field.
            var path = (string)environment["owin.RequestPath"];

            _options.OnIncomingRequest(ctx);
            await _next(environment);
            _options.OnOutgoingRequest(ctx);
        }
    }
}