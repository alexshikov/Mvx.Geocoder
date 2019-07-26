using MvvmCross.Platforms.Ios.Core;
using MvvmCross.ViewModels;
using Mvx.Geocoder.Sample.Core;

namespace Mvx.Geocoder.Sample.Touch
{
	public class Setup : MvxIosSetup
	{
		protected override IMvxApplication CreateApp()
		{
			return new App();
		}
	}
}