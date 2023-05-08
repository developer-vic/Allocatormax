using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Allocatormax
{
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            VConstants.BANNER_ID = VConstants.BANNER_ID_2;
            vStack.Children.Add(new AdControlView12());
        }

        void GoBack(System.Object sender, System.EventArgs e)
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }

        void ShowInterstitial_OnClicked(System.Object sender, System.EventArgs e)
        {
            var dep = DependencyService.Get<IAdControlView34>();
            if (dep != null)
                dep.ShowInterstitial(VConstants.INTERSTITIAL_ID_2);
        }
    }
}
