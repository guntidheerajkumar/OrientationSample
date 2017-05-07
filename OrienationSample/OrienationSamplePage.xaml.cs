using Xamarin.Forms;

namespace OrienationSample
{
    public partial class OrienationSamplePage : ContentPage
    {
        public OrienationSamplePage()
        {
            InitializeComponent();
        }

        void OpenPopupClicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new PopupPage(), true);
        }
    }
}
