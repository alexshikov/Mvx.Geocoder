using System.Linq;
using System.Threading.Tasks;
using MonoTouch.AddressBook;
using MonoTouch.CoreLocation;
using MonoTouch.Foundation;

namespace Mvx.Geocoder.Touch
{
    public class TouchGeocoder : IGeocoder
    {
        public async Task<Address[]> GetAddressesAsync(double latitude, double longitude)
        {
            var geocoder = new CLGeocoder();
            var placemarks = await geocoder.ReverseGeocodeLocationAsync(new CLLocation(latitude, longitude));
            return placemarks.Select(Convert).ToArray();
        }

        public async Task<Address[]> GetAddressesAsync(string addressString)
        {
            var geocoder = new CLGeocoder();
            var placemarks = await geocoder.GeocodeAddressAsync(addressString);
            return placemarks.Select(Convert).ToArray();
        }

        private static Address Convert(CLPlacemark placemark)
        {
            string addressLine = null;

            NSObject value;
            if (placemark.AddressDictionary.TryGetValue(ABPersonAddressKey.Street, out value))
            {
                addressLine = (NSString)value;
            }

            return new Address
            {
                Name = placemark.Name,
                Latitude = placemark.Location.Coordinate.Latitude,
                Longitude = placemark.Location.Coordinate.Longitude,
                Country = placemark.Country,
                PostalCode = placemark.PostalCode,
                Locality = placemark.Locality,
                SubLocality = placemark.SubLocality,
                Thoroughfare = placemark.Thoroughfare,
                SubThoroughfare = placemark.SubThoroughfare,
                AdministrativeArea = placemark.AdministrativeArea,
                SubAdministrativeArea = placemark.SubAdministrativeArea,

                AddressLine = addressLine,
            };
        }
    }
}

