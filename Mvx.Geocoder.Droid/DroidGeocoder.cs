using System;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using System.Linq;

namespace MvxPlugins.Geocoder.Droid
{
	public class DroidGeocoder: IGeocoder
	{
		public async Task<Address[]> GetAddressesAsync (double latitude, double longitude)
		{
			var globals = Mvx.Resolve<Cirrious.CrossCore.Droid.IMvxAndroidGlobals>();
			var geocoder = new Android.Locations.Geocoder (globals.ApplicationContext);

			var addresses = await geocoder.GetFromLocationAsync (latitude, longitude, 10);

			return addresses.Select (Convert).ToArray ();
		}

		private static Address Convert (Android.Locations.Address address)
		{
			return new Address () {
				Latitude = address.Latitude,
				Longitude = address.Longitude,
				Name = address.FeatureName,
				Country = address.CountryName,
				PostalCode = address.PostalCode,
			};
		}
	}
}

