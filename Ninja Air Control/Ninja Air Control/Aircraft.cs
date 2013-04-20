using System;

namespace Ninja_Air_Control
{
    public class Aircraft
    {
        //has a flightplan, that contain data about the trip
        //such as departure, arrival etc.
        // has:
        //-current Position3D
        //-Pilot
        //-current speed (int)
        //-current courseInDegrees (int)
        //-has an AirTrafficController
        //-has a model (string)
        //-has id (string)
        //-has type - military, scheduled, charter, etc. (enum)
        //-hasRVSM (boolean) - used by ConflictDetection
    }
}