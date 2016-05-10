using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace Xamarin.FormsComponents
{
	public class RatingStars : ContentView
	{
		List<Image> starImages { get; set; }

		public RatingStars ()
		{  
			starImages = new List<Image> (); 
			for (int i = 0; i < 5; i++)
				starImages.Add (new Image ());

			StackLayout starsStack = new StackLayout () {
				Orientation = StackOrientation.Horizontal, 
				HorizontalOptions = LayoutOptions.Start, 
				Padding = 0,  
				Spacing = 0, 
				Children = { 
					starImages [0], 
					starImages [1], 
					starImages [2], 
					starImages [3], 
					starImages [4]
				} 
			};  

			Content = starsStack;

			updateStarsDisplay (); 
		}



		public static BindableProperty RatingProperty = 
			BindableProperty.Create<RatingStars, int> (ctrl => ctrl.Rating,
				defaultValue: 0,
				defaultBindingMode: BindingMode.OneWay,
				propertyChanged: (bindable, oldValue, newValue) => {
					var ratingStars = (RatingStars)bindable;
					ratingStars.updateStarsDisplay (); 
				}
			);

		public int Rating {
			get { 
				return (int)GetValue (RatingProperty);
			}
			set { 
				if (value != (int)GetValue (RatingProperty)) {
					SetValue (RatingProperty, value);
				}
			}  
		}

		void updateStarsDisplay ()
		{ 
			for (int i = 0; i < starImages.Count; i++) {
				starImages [i].Source = getStarFileName (i); 
			}
		}

		string getStarFileName (int position)
		{ 
			int currentStarMaxRating = (position + 1) * 2; 

			if (Rating >= currentStarMaxRating) {
				return "star-on.png"; 
			} else if (Rating >= currentStarMaxRating - 1) { 
				return "star-half.png"; 
			} else { 
				return "star-off.png"; 
			}   
		}


	}
}


