using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;

namespace MvxPlugins.Geocoder.Droid
{
    public class Plugin
        : IMvxPlugin
    {
        public void Load()
        {
            Mvx.RegisterSingleton<IGeocoder>(new DroidGeocoder());
        }
    }
}
