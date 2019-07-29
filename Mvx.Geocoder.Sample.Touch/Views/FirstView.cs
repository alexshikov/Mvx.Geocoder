using System;
using Foundation;
using UIKit;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Views;
using Mvx.Geocoder.Sample.Core.ViewModels;

namespace Mvx.Geocoder.Sample.Touch.Views
{
    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
		public Exception Exception
		{
			get { return null; }
			set
			{
				if (!(value is NSErrorException nsError))
					return;

				if (nsError.Domain != "kCLErrorDomain")
					return;

				var code = (CoreLocation.CLError)(int)nsError.Code;
				Console.WriteLine ("---- CL.Error: " + code);
			}
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

			var tableView = new UITableView (UIScreen.MainScreen.Bounds);
			View = tableView;

			var source = new MvxSimpleTableViewSource (tableView, AddressCell.Key);
			tableView.Source = source;

			var search = new UISearchBar ();
			NavigationItem.TitleView = search;

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
			set.Bind(source).To(vm => vm.Items);
			set.Bind(search).To(vm => vm.Search);
			set.Bind (this).For (v => v.Exception).To (vm => vm.Exception);
            set.Apply();
        }
    }
}