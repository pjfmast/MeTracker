using SQLite;

namespace MeTracker.Models {
    // todo p214 - create model Location
    public class Location {
        public Location() { }

        public Location(double latitude, double longitude) {
            Latitude = latitude;
            Longitude = longitude;
        }

        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
