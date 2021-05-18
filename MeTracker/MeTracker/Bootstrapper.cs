using Autofac;
using MeTracker.Repositories;
using MeTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace MeTracker {
    public class Bootstrapper {
        protected ContainerBuilder ContainerBuilder { get; private set; }
        public Bootstrapper() {
            // This virtual method is overriden for each platform
            // to register platform specific 
            Initialize();
            // The building of the Container happens below after the custom registrations on each platform.
            FinishInitialization();
        }


        protected virtual void Initialize() {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            ContainerBuilder = new ContainerBuilder();

            foreach (var type in currentAssembly.DefinedTypes
                .Where(e =>
                e.IsSubclassOf(typeof(Page)) ||
                e.IsSubclassOf(typeof(ViewModel)))) {
                ContainerBuilder.RegisterType(type.AsType());
            }
            // default for Autofac is a new instance for each resolution (InstancePerRequest ?)
            ContainerBuilder.RegisterType<LocationRepository>().As<ILocationRepository>();

        }


        private void FinishInitialization() {
            Autofac.IContainer container = ContainerBuilder.Build();
            Resolver.Initialize(container);
        }
    }
}
