using System;
using System.Collections.Generic;
using System.Text;

namespace MeTracker.Models {
    // todo p242 - Point on the Heat map. One Point represents several visited locations within 200 meter.
    public class Point {
        public Location Location { get; set; }
        public int Count { get; set; } = 1;
        public Xamarin.Forms.Color Heat { get; set; }
    }
}
