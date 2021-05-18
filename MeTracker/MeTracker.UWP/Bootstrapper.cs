using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeTracker.Services;


namespace MeTracker.UWP {
    class Bootstrapper :MeTracker.Bootstrapper {
        public static void Init() {
            var instance = new Bootstrapper();
        }

        protected override void Initialize() {
            base.Initialize();
            ContainerBuilder
                .RegisterType<LocationTrackingService>()
                .As<ILocationTrackingService>()
                .SingleInstance();
        }
    }
}
