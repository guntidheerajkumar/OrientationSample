using Android.App;
using OrienationSample.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ContentPage), typeof(MainPageRenderer))]
namespace OrienationSample.Droid
{
    public class MainPageRenderer : PageRenderer
    {
        public MainPageRenderer()
        {
        }

        protected override void OnWindowVisibilityChanged(Android.Views.ViewStates visibility)
        {
            base.OnWindowVisibilityChanged(visibility);
            var actitiy = (Activity)Context;
            if (visibility == Android.Views.ViewStates.Gone)
            {
                actitiy.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
            }
            else if (visibility == Android.Views.ViewStates.Visible)
            {
                var navigationPage = Xamarin.Forms.Application.Current.MainPage;
                if (navigationPage != null)
                {
                    if (navigationPage.Navigation.ModalStack.Count > 0)
                    {
                        var orientationPage = navigationPage?.Navigation?.ModalStack[0] as IOrientation;
                        if (orientationPage != null)
                        {
                            foreach (var item in orientationPage.SupportOrientation)
                            {
                                switch (item)
                                {
                                    case DeviceOrienation.Portrait:
                                        actitiy.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
                                        break;
                                    case DeviceOrienation.Landscape:
                                        actitiy.RequestedOrientation = Android.Content.PM.ScreenOrientation.Landscape;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        actitiy.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
                    }
                }
            }
        }
    }
}
