using Xamarin.Forms;

namespace Allocatormax
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            VConstants.BANNER_ID = VConstants.BANNER_ID_1;
            vStack.Children.Add(new AdControlView12());
        }

        void NextPage(System.Object sender, System.EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new SecondPage());
        }

        void ShowInterstitial_OnClicked(System.Object sender, System.EventArgs e)
        {
            var dep = DependencyService.Get<IAdControlView34>();
            if (dep != null)
                dep.ShowInterstitial(VConstants.INTERSTITIAL_ID_1);
        }
    }
}
