using System.Linq;
using System.Threading.Tasks;

namespace MvxPlugins.Geocoder.Droid
{
    public class DroidGeocoder : IGeocoder
    {
        public async Task<Address[]> GetAddressesAsync(double latitude, double longitude)
        {
            var globals = Cirrious.CrossCore.Mvx.Resolve<Cirrious.CrossCore.Droid.IMvxAndroidGlobals>();
            var geocoder = new Android.Locations.Geocoder(globals.ApplicationContext);

            var addresses = await geocoder.GetFromLocationAsync(latitude, longitude, 10);

            return addresses.Select(Convert).ToArray();
        }

        public async Task<Address[]> GetAddressesAsync(string addressString)
        {
            var globals = Cirrious.CrossCore.Mvx.Resolve<Cirrious.CrossCore.Droid.IMvxAndroidGlobals>();
            var geocoder = new Android.Locations.Geocoder(globals.ApplicationContext);

            var addresses = await geocoder.GetFromLocationNameAsync(addressString, 10);

            return addresses.Select(Convert).ToArray();
        }

        private static Address Convert(Android.Locations.Address address)
        {
            string addressLine = address.GetAddressLine(0);

            return new Address
            {
                Latitude = address.Latitude,
                Longitude = address.Longitude,
                Name = address.FeatureName,
                Country = address.CountryName,
                PostalCode = address.PostalCode,
                Locality = address.Locality,
                SubLocality = address.SubLocality,
                Thoroughfare = address.Thoroughfare,
                SubThoroughfare = address.SubThoroughfare,
                AdministrativeArea = address.AdminArea,
                SubAdministrativeArea = address.SubAdminArea,

                AddressLine = addressLine,
            };
        }
    }
}

