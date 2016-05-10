using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Xamarin.FormsComponents
{
	public partial class ViewListPage : ContentPage
	{
		ViewModel viewModel { get; set; }

		public ViewListPage ()
		{
			InitializeComponent ();

			viewModel = new ViewModel (); 
			BindingContext = viewModel;

			viewModel.Views.Add (new ItemViewModel () { 
				Text = "RatingStars", 
				Detail = "Readonly RatingStars Component", 
				PageClassName = "RatingStarsPage"
			});

			// Add your page here..
		}

		public async void OnItemSelected (object sender, SelectedItemChangedEventArgs args)
		{
			ItemViewModel itemViewModel = (ItemViewModel)(args.SelectedItem);
			if (null != itemViewModel) {
				((ListView)sender).SelectedItem = null;
				if (null != itemViewModel.PageClassName) {
					Type t = Type.GetType ("Xamarin.FormsComponents." + itemViewModel.PageClassName); 
					if (null != t) {
						ContentPage page = (ContentPage)Activator.CreateInstance (t);
						if (null != page) {
							await this.Navigation.PushAsync (page);
						}
					}
				}
			}
		}

		class ViewModel : ViewModelBase
		{
			public ObservableCollection<ItemViewModel> Views { get; private set; }

			public ViewModel ()
			{
				Views = new ObservableCollection<ItemViewModel> ();
			}
		}

		class ItemViewModel : ViewModelBase
		{
			public string Text { get; set; }

			public string Detail { get; set; }

			public string PageClassName  { get; set; }
		}
	}
}