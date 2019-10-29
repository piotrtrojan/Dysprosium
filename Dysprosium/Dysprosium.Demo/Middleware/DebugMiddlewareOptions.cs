using Microsoft.Owin;
using System;

namespace Dysprosium.Demo.Middleware
{
    public class DebugMiddlewareOptions
    {
        public Action<IOwinContext> OnIncomingRequest { get; set; }
        public Action<IOwinContext> OnOutgoingRequest { get; set; }
    }
}