using System;
using System.Device.Location;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Phone.Maps.Services;

namespace MvvmCross.HotTuna.Plugins.Geocoder.WindowsPhone
{
    public class WindowsPhoneGeocoder : IGeocoder
    {
        public Task<Address[]> GetAddressesAsync(double latitude, double longitude)
        {
            var tcs = new TaskCompletionSource<Address[]>();
            var query = new ReverseGeocodeQuery();

            query.GeoCoordinate = new GeoCoordinate(latitude, longitude);
            query.QueryCompleted += (sender, args) =>
                                    {
                                        if (args.Error != null)
                                        {
                                            tcs.TrySetException(args.Error);
                                        }
                                        else
                                        {
                                            var addresses = args.Result.Select(ConvertMapLocation).ToArray();
                                            tcs.TrySetResult(addresses);
                                        }
                                    };
            query.QueryAsync();
            return tcs.Task;
        }

		public async Task<Address[]> GetAddressesAsync (string addressString)
        {
            throw new Exception("Not implemented exception");
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
