using System;
using System.Threading.Tasks;

namespace MvxPlugins.Geocoder
{
	public interface IGeocoder
	{
		/// <summary>
		/// Returns the list of addresses using specified location
		/// </summary>
		/// <returns>The list of addresses.</returns>
		/// <param name="latitude">Latitude.</param>
		/// <param name="longitude">Longitude.</param>
		Task<Address[]> GetAddressesAsync (double latitude, double longitude);

		/// <summary>
		/// Returns the list of locations (longitude/latitude) from a human readable address or region.
		/// </summary>
		/// <returns>The list of locations batched into addresses.</returns>
		/// <param name="addressString">Human readable address.</param>
		Task<Address[]> GetAddressesAsync (string addressString);
	}
}

