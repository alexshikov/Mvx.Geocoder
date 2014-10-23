using Cirrious.CrossCore.Plugins;

namespace MvxPlugins.Geocoder.Droid
{
    public class Plugin
        : IMvxPlugin
    {
        public void Load()
        {
            Cirrious.CrossCore.Mvx.RegisterSingleton<IGeocoder>(new DroidGeocoder());
        }
    }
}
