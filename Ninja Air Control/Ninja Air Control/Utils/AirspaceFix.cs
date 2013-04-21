namespace NinjaAirControl.Utils
{
    /// <summary>
    /// Represents a coordinate in the airspace
    /// Could be eighter a radio station or a simple navigation point
    /// Some fixes require Report from pilot to controller, others do not
    /// </summary>
    public class AirspaceFix
    {
        public bool IsVisited { get; private set; }

        public AirspaceFix(Position3D coordinates, bool isRadioNavigationalPoint, bool isMandatoryToReport)
        {
            this.Coordinates = coordinates;
            this.IsMandatoryToReport = isMandatoryToReport;
            this.IsRadioNavigationalPoint = isRadioNavigationalPoint;
            this.IsVisited = false;
        }

        public bool IsRadioNavigationalPoint { get; private set; }

        public bool IsMandatoryToReport { get; private set; }

        public Position3D Coordinates { get; private set; }

        public void MarkAsVisited()
        {
            this.IsVisited = true;
        }
        
        // has:
        //-Position3D
        //-isRadioNav (bool) - is it a radio navigational point or not
        //-isMandatoryToReport (bool) - does the aircraft have to report to AirTrafficController
    }
}