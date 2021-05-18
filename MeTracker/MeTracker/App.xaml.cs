using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeTracker {
    public partial class App : Application {
        private readonly bool isStartUp;

        public App() {
            InitializeComponent();

            //MainPage = new MainPage();
            // Page 144, the Resolver uses Autofac to figure out the dependencies we need in order to create the MainView instance.
            // it looks at the constructor of the MainView and sees it requires a MainViewModel (which may depend also on constructor injection)
            MainPage = Resolver.Resolve<MainPage>();

            isStartUp = false;
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
            if (!isStartUp) {
                MainPage = Resolver.Resolve<MainPage>();
            }
        }
    }
}
