using Prism.Unity;
using EfficienSee.Views;
using System.Diagnostics;
using EfficienSee.Services;
using Microsoft.Practices.Unity;

namespace EfficienSee
{
    public partial class App : PrismApplication
    {
        /// <summary>
        /// Default constructor is here solely to allow the Xamarin Forms previewer to function.
        /// </summary>
        public App()
        {
            InitializeComponent();
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(App)}:  ctor ***** THIS SHOULD NEVER BE CALLED!!!");
        }

        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(App)}:  ctor -- Correct for runtime.");
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnInitialized)}");

            NavigationService.NavigateAsync($"MainPage");
        }

        protected override void RegisterTypes()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(RegisterTypes)}");
            RegisterTypesForNavigation();
            RegisterSingletons();
        }

        private void RegisterSingletons()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(RegisterSingletons)}");
            Container.RegisterType<ITimeSavingsCalculator, TimeSavingsCalculator>(new ContainerControlledLifetimeManager());
        }

        private void RegisterTypesForNavigation()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(RegisterTypesForNavigation)}");
            Container.RegisterTypeForNavigation<MainPage>();
        }
    }
}

