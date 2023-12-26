namespace OnlineVehiclesApplication.DataTransferObjects
{
    public class Vehicles
    {
        public string VehicleId { get; set; }
        public string Vin { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
