using MeTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MeTracker {
    public partial class MainPage : ContentPage {
        public MainPage(MainViewModel viewModel) {
            InitializeComponent();

            //page 138
            BindingContext = viewModel;

            MainThread.BeginInvokeOnMainThread(async () => {
                // Code to run on the main thread
                var location = await Geolocation.GetLocationAsync();
                Map.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Position(location.Latitude, location.Longitude),
                    Distance.FromKilometers(5)));
            });

        }
    }
}
