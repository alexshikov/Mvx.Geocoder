using MvvmCross;
using MvvmCross.Plugin;

namespace Mvx.Geocoder.Platforms.Ios
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
