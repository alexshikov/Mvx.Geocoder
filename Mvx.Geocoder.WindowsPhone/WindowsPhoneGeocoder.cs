using System;
using System.Device.Location;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Phone.Maps.Services;

namespace MvxPlugins.Geocoder.WindowsPhone
{
    public class WindowsPhoneGeocoder : IGeocoder
    {
        public async Task<Address[]> GetAddressesAsync(double latitude, double longitude)
        {
            var result = await new ReverseGeocodeQuery { GeoCoordinate = new GeoCoordinate(latitude, longitude) }.ExecuteAsync();
            return result.Select(ConvertMapLocation).ToArray();
        }

        public async Task<Address[]> GetAddressesAsync(string addressString)
        {
            var result = await new GeocodeQuery { SearchTerm = addressString }.ExecuteAsync();
            return result.Select(ConvertMapLocation).ToArray();
        }

        private Address ConvertMapLocation(MapLocation location)
        {
            return new Address
            {
                Country = location.Information.Address.Country,
                AddressLine = string.Format("{0} {1}", location.Information.Address.Street, location.Information.Address.HouseNumber).Trim(),
                AdministrativeArea = location.Information.Address.State,
                Latitude = location.GeoCoordinate.Latitude,
                Longitude = location.GeoCoordinate.Longitude,
                Locality = location.Information.Address.City,
                Name = location.Information.Name,
                PostalCode = location.Information.Address.PostalCode,
                SubAdministrativeArea = location.Information.Address.Province,
                SubLocality = location.Information.Address.District,
                SubThoroughfare = location.Information.Address.Street,
                Thoroughfare = location.Information.Address.HouseNumber
            };
        }
    }
}
