using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using System;

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
				var nsError = value as NSErrorException;
				if (nsError != null)
				{
					if (nsError.Domain == "kCLErrorDomain")
					{
						var code = (CoreLocation.CLError)(int)nsError.Code;
						Console.WriteLine ("---- CL.Error: " + code);
					}
				}
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

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
			set.Bind(source).To(vm => vm.Items);
			set.Bind(search).To(vm => vm.Search);
			set.Bind (this).For (v => v.Exception).To (vm => vm.Exception);
            set.Apply();
        }
    }
}