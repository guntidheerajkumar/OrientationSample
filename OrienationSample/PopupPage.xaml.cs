using Xamarin.Forms;

namespace OrienationSample
{
    public partial class PopupPage : ContentPage, IOrientation
    {
        public PopupPage()
        {
            InitializeComponent();
        }

        public DeviceOrienation[] SupportOrientation
        {
            get
            {
                return new[] { DeviceOrienation.Portrait, DeviceOrienation.Landscape };
            }
        }

        void ClosePopupClicked(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}
