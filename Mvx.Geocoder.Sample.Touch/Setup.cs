using MvvmCross.iOS.Platform;
using MvvmCross.Core.ViewModels;
using UIKit;

namespace Mvx.Geocoder.Sample.Touch
{
	public class Setup : MvxIosSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new Core.App();
		}
	}
}