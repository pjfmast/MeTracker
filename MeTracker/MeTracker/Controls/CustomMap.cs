using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps; // Not: Xamarin.Essentials.Map


namespace MeTracker.Controls {
    // todo p247 - Create class CustomMap - a Map extended with with a (bindable) PointsProperty
    // todo p249 - change use of Xamarin.Forms Map into this CustomMap
    public class CustomMap : Map {
        public static BindableProperty PointsProperty 
            = BindableProperty.Create(
                nameof(Points),
                typeof(List<Models.Point>), 
                typeof(CustomMap), 
                new List<Models.Point>());

        public List<Models.Point> Points {
            get => GetValue(PointsProperty) as List<Models.Point>;
            set => SetValue(PointsProperty, value);
        }
    }
}
