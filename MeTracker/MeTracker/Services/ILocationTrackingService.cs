using System;
using System.Collections.Generic;
using System.Text;

namespace MeTracker.Services {
    // todo p217 - create location tracking service - implemented platform specific as a background service
    public interface ILocationTrackingService {
        void StartTracking();
    }
}
