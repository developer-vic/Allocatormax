using Xamarin.Forms;

namespace Allocatormax
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts


        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
