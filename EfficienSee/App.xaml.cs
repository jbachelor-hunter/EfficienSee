using Prism.Unity;
using EfficienSee.Views;
using System.Diagnostics;

namespace EfficienSee
{
    public partial class App : PrismApplication
    {
        public App() { InitializeComponent(); }

        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnInitialized)}");

            NavigationService.NavigateAsync($"MainPage");
        }

        protected override void RegisterTypes()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(RegisterTypes)}");

            Container.RegisterTypeForNavigation<MainPage>();
        }
    }
}

