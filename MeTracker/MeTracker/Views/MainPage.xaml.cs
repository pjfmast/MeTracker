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
    // todo p218 - create MainView
    public partial class MainView : ContentPage {
        public MainView(MainViewModel viewModel) {
            InitializeComponent();

            BindingContext = viewModel;

            // todo p222 - center map on position. Run this on the main ui thread.
            MainThread.BeginInvokeOnMainThread(async () => {
                // Code to run on the main thread
                var location = await Geolocation.GetLocationAsync();
                Map.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Position(location.Latitude, location.Longitude),
                    Distance.FromKilometers(5)));
            });

            Xamarin.Forms.Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                Task.Run(async () => await viewModel.LoadData());

                return true;
            });


        }
    }
}
