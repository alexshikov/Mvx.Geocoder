using System;

namespace MvxPlugins.Geocoder
{
	public class Address
	{
		public double Latitude { get; set; }

		public double Longitude { get; set; }

		public string Name { get; set; }

		public string Country { get; set; }

		public string PostalCode { get; set; }

		// TODO Add more fields

		public Address ()
		{
		}
	}
}

