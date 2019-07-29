using System.Linq;
using System.Threading.Tasks;
using Android.App;
using MvvmCross;

namespace Mvx.Geocoder.Platforms.Android
{
	[Preserve(AllMembers = true)]
	public class MvxGeocoder : IGeocoder
	{
		public async Task<Address[]> GetAddressesAsync(double latitude, double longitude)
		{
			var geocoder = new global::Android.Locations.Geocoder(Application.Context);
			var addresses = await geocoder.GetFromLocationAsync(latitude, longitude, 10);
			return addresses.Select(Convert).ToArray();
		}

		public async Task<Address[]> GetAddressesAsync(string addressString)
		{
			var geocoder = new global::Android.Locations.Geocoder(Application.Context);
			var addresses = await geocoder.GetFromLocationNameAsync(addressString, 10);
			return addresses.Select(Convert).ToArray();
		}

		private static Address Convert(global::Android.Locations.Address address)
		{
			var addressLine = address.GetAddressLine(0);
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
