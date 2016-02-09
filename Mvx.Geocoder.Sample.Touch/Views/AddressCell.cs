﻿
using System;
using System.Drawing;

using Foundation;
using UIKit;
using MvxPlugins.Geocoder;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;

namespace Mvx.Geocoder.Sample.Touch.Views
{
	public partial class AddressCell : MvxTableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("AddressCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("AddressCell");

		public Address Address
		{
			get { return null; }
			set
			{
				var address = value == null
					? "<null>"
					: string.Format ("{0}, {1}: {2}", value.Name, value.AdministrativeArea, value.PostalCode);
				TextLabel.Text = address;
			}
		}

		public AddressCell (IntPtr handle) : base (handle)
		{
			this.DelayBind (() => {

				var set = this.CreateBindingSet<AddressCell, Address> ();
				set.Bind (this).For (v => v.Address).To (vm => vm);
				set.Apply ();

			});
		}

		public static AddressCell Create ()
		{
			return (AddressCell)Nib.Instantiate (null, null) [0];
		}
	}
}
