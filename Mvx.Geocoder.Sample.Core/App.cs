using MvvmCross.ViewModels;
using Mvx.Geocoder.Sample.Core.ViewModels;

namespace Mvx.Geocoder.Sample.Core
{
	public class App : MvxApplication
	{
		public override void Initialize()
		{
			//CreatableTypes()
			//	.EndingWith("Service")
			//	.AsInterfaces()
			//	.RegisterAsLazySingleton();

			RegisterAppStart<FirstViewModel>();
		}
	}
}
