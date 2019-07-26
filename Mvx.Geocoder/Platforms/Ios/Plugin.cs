using MvvmCross;
using MvvmCross.Plugin;

namespace Mvx.Geocoder.Platforms.Ios
{
	namespace Mvx.Geocoder.Platforms.Android
	{
		[MvxPlugin]
		[Preserve(AllMembers = true)]
		public class Plugin : IMvxPlugin
		{
			public void Load()
			{
				MvvmCross.Mvx.IoCProvider.RegisterType<IGeocoder, MvxGeocoder>();
			}
		}
	}
}
