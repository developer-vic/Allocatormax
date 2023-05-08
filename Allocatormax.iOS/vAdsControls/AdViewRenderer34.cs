using Google.MobileAds;
using UIKit;
using Xamarin.Forms;
using Allocatormax.iOS;
using Foundation;
using System.Threading.Tasks;

//https://developers.google.com/admob/ios/interstitial

[assembly: Dependency(typeof(AdViewRenderer34))]
namespace Allocatormax.iOS
{
    public class AdViewRenderer34 : IAdControlView34
    {
        InterstitialAd adView = null;

        public async Task ShowInterstitial(string interID)
        {
            adView = await InterstitialAd.LoadAsync(interID, GetRequest());
            adView.Present(GetVisibleViewController());

            //version 7.11.0
            //adView = new InterstitialAd(interID);
            //// Wire AdReceived event to know when the Ad is ready to be displayed
            //adView.AdReceived += (object sender, EventArgs e) =>
            //{
            //    //ad has come in
            //    adView.PresentFromRootViewController(GetVisibleViewController());
            //};
            //adView.ReceiveAdFailed += (object sender, InterstitialDidFailToReceiveAdWithErrorEventArgs e) =>
            //{
            //    //ad has come in
            //    ToastMessage("Ads failed to load, try again later");
            //};

            //adView.LoadRequest(GetRequest());
            //adView.PresentFromRootViewController(GetVisibleViewController());
        }

        Request GetRequest()
        {
            var request = Request.GetDefaultRequest();
            // Requests test ads on devices you specify. Your test device ID is printed to the console when
            // an ad request is made. GADBannerView automatically returns test ads when running on a
            // simulator. After you get your device ID, add it here
            //request.TestDevices = new [] { Request.SimulatorId.ToString () };
            return request;
        }

        UIViewController GetVisibleViewController()
        {
            var rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;

            if (rootController.PresentedViewController == null)
                return rootController;

            if (rootController.PresentedViewController is UINavigationController)
            {
                return ((UINavigationController)rootController.PresentedViewController).VisibleViewController;
            }

            if (rootController.PresentedViewController is UITabBarController)
            {
                return ((UITabBarController)rootController.PresentedViewController).SelectedViewController;
            }

            return rootController.PresentedViewController;
        }

        NSTimer alertDelay;
        UIAlertController alert;
        void ToastMessage(string message)
        {
            alertDelay = NSTimer.CreateScheduledTimer(2.0, (obj) =>
            {
                dismissMessage();
            });
            alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }

        void dismissMessage()
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }
            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }

    }

}