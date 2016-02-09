using MvvmCross.Platform.Plugins;
using MvvmCross.Platform;

namespace MvxPlugins.Geocoder.Touch
{
    public class Plugin
        : IMvxPlugin
    {
        public void Load()
        {
            Mvx.RegisterSingleton<IGeocoder>(new TouchGeocoder());
        }
    }
}

