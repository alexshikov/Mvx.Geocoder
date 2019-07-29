using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using MvvmCross.ViewModels;

namespace Mvx.Geocoder.Sample.Core.ViewModels
{
	public class FirstViewModel : MvxViewModel
	{
		#region NotifyProperty Search

		private string search;
		public string Search
		{
			get => search;
			set
			{
				SetProperty(ref search, value);
				Refresh();
			}
		}

		#endregion

		#region NotifyProperty Items

		private IList<Address> items;
		public IList<Address> Items
		{
			get => items;
			set => SetProperty(ref items, value);
		}

		#endregion

		#region NotifyProperty Exception

		private Exception exception;
		public Exception Exception
		{
			get => exception;
			set => SetProperty(ref exception, value);
		}

		#endregion

		private readonly IGeocoder geocoder;

		public FirstViewModel(IGeocoder geocoder)
		{
			this.geocoder = geocoder;
		}

		private async Task Refresh()
		{
			try
			{
				Items = await geocoder.GetAddressesAsync(Search).ConfigureAwait(false);
			}
			catch (Exception e)
			{
				Exception = e;
				Items = null;
			}
		}
	}
}
