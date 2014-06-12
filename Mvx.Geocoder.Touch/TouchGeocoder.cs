using System.Threading.Tasks;
using MonoTouch.CoreLocation;
using System.Linq;

namespace MvxPlugins.Geocoder.Touch
{
	public class TouchGeocoder: IGeocoder
	{
		public async Task<Address[]> GetAddressesAsync (double latitude, double longitude)
		{
			var geocoder = new CLGeocoder ();
			var placemarks = await geocoder.ReverseGeocodeLocationAsync (new CLLocation (latitude, longitude));
			return placemarks.Select (Convert).ToArray ();
		}

		private static Address Convert (CLPlacemark placemark)
		{
			return new Address () {
				Name = placemark.Name,
				Latitude = placemark.Location.Coordinate.Latitude,
				Longitude = placemark.Location.Coordinate.Longitude,
				Country = placemark.Country,
				PostalCode = placemark.PostalCode,
			};
		}
	}
}

