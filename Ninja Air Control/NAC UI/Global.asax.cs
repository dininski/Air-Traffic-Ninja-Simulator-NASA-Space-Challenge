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

        private void FlightsProcessorOnApproachingBadWeather(object sender, FlightEventArgs e)
        {
            //throw new NotImplementedException();
            //TODO Send the data to interface
            switch (e.WarningLevel)
            {
                case WarningLevel.Normal:
                    //DO nothing we will try to process this one
                    break;
                case WarningLevel.High:
                    RealTimeUpdateHub.InvokeGlobalMessageForBadWeather(e.Flights[0], e.WarningLevel);
                    break;
                case WarningLevel.Critical:
                    RealTimeUpdateHub.InvokeGlobalMessageForBadWeather(e.Flights[0], e.WarningLevel);
                    break;
                default:
                    RealTimeUpdateHub.InvokeGlobalMessageForBadWeather(e.Flights[0], e.WarningLevel);
                    break;
            }            
        }

        void FlightsProcessor_PossibleCollision(object sender, NinjaAirControl.Processing.FlightEventArgs e)
        {
            //throw new NotImplementedException();
            //TODO Send the data to interface
            switch (e.WarningLevel)
            {
                case WarningLevel.Normal:
                    //DO nothing we will try to process this one
                    break;
                case WarningLevel.High:
                    RealTimeUpdateHub.InvokeGlobalMessageForCollision(e.Flights[0], e.Flights[1], e.WarningLevel);
                    break;
                case WarningLevel.Critical:
                    RealTimeUpdateHub.InvokeGlobalMessageForCollision(e.Flights[0], e.Flights[1], e.WarningLevel);
                    break;
                default:
                    RealTimeUpdateHub.InvokeGlobalMessageForCollision(e.Flights[0], e.Flights[1], e.WarningLevel);
                    break;
            }
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