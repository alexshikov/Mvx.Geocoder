using System;
using Cirrious.CrossCore.Plugins;
using Cirrious.CrossCore;

namespace MvxPlugins.Geocoder.Droid
{
	public class Plugin
		: IMvxPlugin
	{
		public void Load()
		{
			Mvx.RegisterSingleton<IGeocoder>(new DroidGeocoder ());
		}
	}
}
