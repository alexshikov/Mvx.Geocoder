using Cirrious.CrossCore.Plugins;

namespace MvxPlugins.Geocoder.WindowsPhone
{
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Cirrious.CrossCore.Mvx.RegisterSingleton<IGeocoder>(new WindowsPhoneGeocoder());
        }
    }    

}
