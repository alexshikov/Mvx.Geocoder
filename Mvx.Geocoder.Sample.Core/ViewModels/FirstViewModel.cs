using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;
using MvxPlugins.Geocoder;
using System;
using System.Diagnostics;

namespace Mvx.Geocoder.Sample.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
		#region NotifyProperty Search

		private string _Search;

		public string Search {
			get { return _Search; }
			set {
				_Search = value;
				RaisePropertyChanged (() => this.Search);
				Refresh ();
			}
		}

		#endregion

		#region NotifyProperty Items

		private IList<Address> _Items;

		public IList<Address> Items {
			get { return _Items; }
			set {
				_Items = value;
				RaisePropertyChanged (() => this.Items);
			}
		}

		#endregion

		#region NotifyProperty Exception

		private Exception _Exception;

		public Exception Exception {
			get { return _Exception; }
			set {
				_Exception = value;
				RaisePropertyChanged (() => this.Exception);
			}
		}

		#endregion

		private readonly IGeocoder geocoder;

		public FirstViewModel (IGeocoder geocoder)
		{
			this.geocoder = geocoder;
		}

		private async void Refresh ()
		{
			try 
			{
				Items = await geocoder.GetAddressesAsync (Search).ConfigureAwait (false);
			}
			catch (Exception e)
			{
				Exception = e;
				Items = null;
			}
		}
    }
}
