using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using MvvmCross.ViewModels;

namespace Mvx.Geocoder.Sample.Core.ViewModels
{
	public class FirstViewModel : MvxViewModel
	{
		#region NotifyProperty Search

		private string _search;
		public string Search
		{
			get => _search;
			set
			{
				SetProperty(ref _search, value);
				Refresh();
			}
		}

		#endregion

		#region NotifyProperty Items

		private IList<Address> _items;
		public IList<Address> Items
		{
			get => _items;
			set => SetProperty(ref _items, value);
		}

		#endregion

		#region NotifyProperty Exception

		private Exception _exception;
		public Exception Exception
		{
			get => _exception;
			set => SetProperty(ref _exception, value);
		}

		#endregion

		private readonly IGeocoder _geocoder;

		public FirstViewModel(IGeocoder geocoder)
		{
			_geocoder = geocoder;
		}

		private async Task Refresh()
		{
			try
			{
				Items = await _geocoder.GetAddressesAsync(Search).ConfigureAwait(false);
			}
			catch (Exception e)
			{
				Exception = e;
				Items = null;
			}
		}
	}
}
