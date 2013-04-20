using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace NAC_UI
{
    public class RealTimeUpdateHub : Hub
    {
        private static int _X = 700;
        private static int _Y = 500;

        public void LoadActivePlanes()
        {
            Clients.Caller.LoadActivePlanesAndAirports(JsonConvert.SerializeObject(MockUpDataSource.Planes), JsonConvert.SerializeObject(MockUpDataSource.Airports));
        }

        public static void InvokeGlobalMessage(object dummyObj)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeUpdateHub>();

            context.Clients.All.updateCoordinates(JsonConvert.SerializeObject(MockUpDataSource.GetUpdatedLocations()));
        }
    }
}