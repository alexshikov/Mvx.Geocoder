using Cirrious.CrossCore.Plugins;

namespace Mvx.Geocoder.Touch
{
    public class Plugin
        : IMvxPlugin
    {
        public void Load()
        {
            Cirrious.CrossCore.Mvx.RegisterSingleton<IGeocoder>(new TouchGeocoder());
        }
    }
}

