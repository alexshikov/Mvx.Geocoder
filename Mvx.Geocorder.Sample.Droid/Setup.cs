using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.ViewModels;
using Mvx.Geocoder.Sample.Core;

namespace Mvx.Geocorder.Sample.Droid
{
	public class Setup : MvxAndroidSetup
	{
		protected override IMvxApplication CreateApp()
		{
			return new App();
		}
	}
}