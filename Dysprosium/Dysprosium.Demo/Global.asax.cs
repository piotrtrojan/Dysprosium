﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dysprosium.Demo
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapRoute(name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" });
        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}