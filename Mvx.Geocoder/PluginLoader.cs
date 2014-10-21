using Cirrious.CrossCore.Plugins;

namespace MvvmCross.HotTuna.Plugins.Geocoder
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

