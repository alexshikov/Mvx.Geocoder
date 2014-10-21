using Cirrious.CrossCore.Plugins;

namespace MvvmCross.HotTuna.Plugins.Geocoder.Droid
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
