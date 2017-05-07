using Foundation;
using OrienationSample.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ContentPage), typeof(MainPageRenderer))]
namespace OrienationSample.iOS
{
    public class MainPageRenderer : PageRenderer
    {
        public MainPageRenderer()
        {
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            var key = new NSString("orientation");
            var value = new NSNumber((int)UIInterfaceOrientation.Portrait);
            UIDevice.CurrentDevice.SetValueForKey(value, key);
        }
    }
}
