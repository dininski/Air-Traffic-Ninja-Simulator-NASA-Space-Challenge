using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;
using NAC_UI.Flights;
using NinjaAirControl.Processing;


namespace NAC_UI
{
    public class Global : System.Web.HttpApplication
    {        
        private Timer timer; // Timer

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapHubs();
            PlaneDataSource.LoadData();
            TimerCallback callback = RealTimeUpdateHub.InvokeGlobalMessage;
            
            //Initialize the processor
            Globals.FlightsProcessor = new FlightProcessor();
            Globals.FlightsProcessor.ApproachingBadWeather += FlightsProcessorOnApproachingBadWeather;
            Globals.FlightsProcessor.PossibleCollision += FlightsProcessor_PossibleCollision;

            // Update the position of the airplane
            timer = new Timer(callback, null, 1000, 1000);
        }

        private void FlightsProcessorOnApproachingBadWeather(object sender, FlightEventArgs flightEventArgs)
        {
            //throw new NotImplementedException();
            //TODO Send the data to interface
        }

        void FlightsProcessor_PossibleCollision(object sender, NinjaAirControl.Processing.FlightEventArgs e)
        {
            //throw new NotImplementedException();
            //TODO Send the data to interface
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