using Cirrious.CrossCore.Plugins;

namespace MvvmCross.HotTuna.Plugins.Geocoder.WindowsPhone
{
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Cirrious.CrossCore.Mvx.RegisterSingleton<IGeocoder>(new WindowsPhoneGeocoder());
        }
    }    

}
