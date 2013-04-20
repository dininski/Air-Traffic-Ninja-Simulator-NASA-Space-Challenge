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

        public void UpdateCoordinates() 
        {
            Random rand = new Random();
            _X = _X + rand.Next(-3,3);
            _Y = _Y + rand.Next(-3,3);
            var newCoords = new
            {
                X = _X,
                Y = _Y
            };

            Clients.All.updateCoordinates(JsonConvert.SerializeObject(newCoords));
        }

        public static void InvokeGlobalMessage(object dummyObj)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeUpdateHub>();
            Random rand = new Random();
            _X = _X + rand.Next(-3, 3);
            _Y = _Y + rand.Next(-3, 3);
            var newCoords = new
            {
                X = _X,
                Y = _Y
            };

            context.Clients.All.updateCoordinates(JsonConvert.SerializeObject(newCoords));
        }
    }
}