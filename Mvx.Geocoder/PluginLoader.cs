using Cirrious.CrossCore.Plugins;

namespace MvxPlugins.Geocoder
{
	public class PluginLoader: IMvxPluginLoader
	{
		public static readonly PluginLoader Instance = new PluginLoader();

		public void EnsureLoaded()
		{
			var manager = Cirrious.CrossCore.Mvx.Resolve<IMvxPluginManager>();
			manager.EnsurePlatformAdaptionLoaded<PluginLoader>();
		}
	}
}

