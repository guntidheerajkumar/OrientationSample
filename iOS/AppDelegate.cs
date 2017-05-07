
using Foundation;
using UIKit;

namespace OrienationSample.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, UIWindow forWindow)
        {
            if (Xamarin.Forms.Application.Current == null || Xamarin.Forms.Application.Current.MainPage == null)
            {
                return UIInterfaceOrientationMask.Portrait;
            }

            var navigationPage = Xamarin.Forms.Application.Current.MainPage;
            if (navigationPage != null)
            {
                if (navigationPage.Navigation.ModalStack.Count > 0)
                {
                    var orientationPage = navigationPage?.Navigation?.ModalStack[0] as IOrientation;
                    if (orientationPage != null)
                    {
                        UIInterfaceOrientationMask supportMask = new UIInterfaceOrientationMask();
                        foreach (var item in orientationPage.SupportOrientation)
                        {
                            switch (item)
                            {
                                case DeviceOrienation.Portrait:
                                    supportMask |= UIInterfaceOrientationMask.Portrait;
                                    break;
                                case DeviceOrienation.Landscape:
                                    supportMask |= UIInterfaceOrientationMask.Landscape;
                                    break;
                                default:
                                    break;
                            }
                        }
                        return supportMask;
                    }
                }
                else
                {
                    return UIInterfaceOrientationMask.Portrait;
                }
            }
            return UIInterfaceOrientationMask.Portrait;
        }
    }
}
