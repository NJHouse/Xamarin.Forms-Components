using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Xamarin.FormsComponents
{
	public partial class RatingStarsPage : ContentPage
	{
		ViewModel viewModel { get; set; }

		public RatingStarsPage ()
		{
			InitializeComponent ();

			viewModel = new ViewModel ();
			BindingContext = viewModel;
		}
	}

	class ViewModel : ViewModelBase
	{
		int rating { get; set; }

		public int Rating {
			get {
				return rating;
			}
			set {
				if (rating != value) {
					rating = value;
					RaisePropertyChanged ();
				}
			}
		}
	}


}

