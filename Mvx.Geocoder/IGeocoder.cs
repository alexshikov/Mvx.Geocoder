using System;
using System.Threading.Tasks;

namespace MvxPlugins.Geocoder
{
	public interface IGeocoder
	{
		Task<Address[]> GetAddressesAsync (double latitude, double longitude);

        Task<Coordinates[]> GetCoordinatesAsync(string addressString);
	}
}

