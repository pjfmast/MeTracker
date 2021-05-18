using MeTracker.Repositories;
using MeTracker.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MeTracker.ViewModels {
    // todo p223 - create MainViewModel
    public class MainViewModel : ViewModel {
        public readonly ILocationRepository locationRepository;
        public readonly ILocationTrackingService locationTrackingService;

        public MainViewModel(ILocationTrackingService locationTrackingService, ILocationRepository locationRepository) {
            this.locationTrackingService = locationTrackingService;
            this.locationRepository = locationRepository;

            MainThread.BeginInvokeOnMainThread(async () => {
                locationTrackingService.StartTracking();
                await LoadData();
            });
        }

        // todo p243-244 - extend MainViewModel with functionality to group visited Locations in Points on the heat map
        private async Task LoadData() {
            var locations = await locationRepository.GetAll();
            var pointList = new List<Models.Point>();

            foreach (var location in locations) {
                //If no points exist, create a new one an continue to the next location in the list
                if (!pointList.Any()) {
                    pointList.Add(new Models.Point() { Location = location });
                    continue;
                }

                var pointFound = false;

                //try to find a point for the current location
                foreach (var point in pointList) {
                    var distance = Xamarin.Essentials.Location.CalculateDistance(
                                       new Xamarin.Essentials.Location(point.Location.Latitude, point.Location.Longitude),
                                       new Xamarin.Essentials.Location(location.Latitude, location.Longitude), DistanceUnits.Kilometers);

                    if (distance < 0.2) {
                        pointFound = true;
                        point.Count++;
                        break;
                    }
                }

                //if no point is found, add a new Point to the list of points
                if (!pointFound) {
                    pointList.Add(new Models.Point() { Location = location });
                }

                if (pointList == null || !pointList.Any()) {
                    return;
                }

                var pointMax = pointList.Select(x => x.Count).Max();
                var pointMin = pointList.Select(x => x.Count).Min();
                var diff = (float)(pointMax - pointMin);

                foreach (var point in pointList) {
                    // todo p245 calculate the heat between 0 (Red) and 240 (Blue) on the scale
                    var heat = (2f / 3f) - ((float)point.Count / diff);
                    point.Heat = Color.FromHsla(heat, 1, 0.5);
                }
            }

            Points = pointList;
        }

        private List<Models.Point> points;
        public List<Models.Point> Points {
            get => points;
            set {
                points = value;
                RaisePropertyChanged(nameof(Points));
            }
        }
    }
}
