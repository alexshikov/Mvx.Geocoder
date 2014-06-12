using System;
using System.Threading.Tasks;

namespace Mvx.Geocoder
{
	public interface IGeocoder
	{
		Task<Address[]> GetAddressesAsync (double latitude, double longitude);
	}
}

