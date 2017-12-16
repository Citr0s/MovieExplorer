using System;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace MovieExplorer.Helpers
{
    public class LocationHelper
    {
        public static async Task<Geoposition> GetPosition()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();

            if (accessStatus != GeolocationAccessStatus.Allowed)
                return null;

            var geoLocator = new Geolocator {DesiredAccuracyInMeters = 0};
            var position = await geoLocator.GetGeopositionAsync();
            return position;
        }
    }
}