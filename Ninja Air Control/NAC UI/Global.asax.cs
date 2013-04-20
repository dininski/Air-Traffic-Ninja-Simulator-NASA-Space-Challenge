using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;


namespace NAC_UI
{
    public class Global : System.Web.HttpApplication
    {        
        private Timer timer; // Timer

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapHubs();

            TimerCallback callback = RealTimeUpdateHub.InvokeGlobalMessage;

            // Update the position of the airplane
            timer = new Timer(callback, null, 1000, 1000);
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