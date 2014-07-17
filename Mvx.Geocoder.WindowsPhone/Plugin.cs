using Cirrious.CrossCore.Plugins;
using MvxPlugins.Geocoder;

namespace Mvx.Geocoder.WindowsPhone
{
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Cirrious.CrossCore.Mvx.RegisterSingleton<IGeocoder>(new WindowsPhoneGeocoder());
        }
    }    

}
