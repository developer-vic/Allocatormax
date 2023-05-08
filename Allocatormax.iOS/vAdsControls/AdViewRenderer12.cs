using CoreGraphics;
using Google.MobileAds;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Allocatormax;
using Allocatormax.iOS;

//https://montemagno.com/xamarinforms-google-admob-ads-in-ios/
[assembly: ExportRenderer(typeof(AdControlView12), typeof(AdViewRenderer12))]
namespace Allocatormax.iOS
{
    public class AdViewRenderer12 : ViewRenderer<AdControlView12, BannerView>
    {
        BannerView adView;
        BannerView CreateNativeAdControl()
        {
            //if (adView != null)
            //    return adView;

            // Setup your BannerView, review AdSizeCons class for more Ad sizes. 
            adView = new BannerView(size: AdSizeCons.SmartBannerPortrait, origin:
                new CGPoint(0, UIScreen.MainScreen.Bounds.Size.Height -
                AdSizeCons.Banner.Size.Height))
            {
                //AdUnitID = VConstants.BANNER_ID, 
                RootViewController = GetVisibleViewController()
            };
            adView.AdUnitId = VConstants.BANNER_ID;

            // Wire AdReceived event to know when the Ad is ready to be displayed
            adView.AdReceived += (object sender, EventArgs e) =>
            {
                //ad has come in
            };

            adView.ReceiveAdFailed += (object sender, BannerViewErrorEventArgs e) =>
            {
                //ad has come in
            };

            adView.LoadRequest(GetRequest());
            return adView;
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

        /// 
        /// Gets the visible view controller.
        /// 
        /// The visible view controller.
        
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

        protected override void OnElementChanged(ElementChangedEventArgs<AdControlView12> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                CreateNativeAdControl();
                SetNativeControl(adView);
            }
        }
    }
}