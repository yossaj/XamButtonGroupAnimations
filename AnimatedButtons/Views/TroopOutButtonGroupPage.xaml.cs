using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnimatedButtons.Views
{
    public partial class TroopOutButtonGroupPage : ContentPage
    {
        double deviceWidth;
        public TroopOutButtonGroupPage()
        {
            InitializeComponent();
            SetImageButtonSource();
            deviceWidth = Application.Current.MainPage.Width;
        }

        public void SetImageButtonSource()
        {
            string path = "AnimatedButtons.Images.";
            Assembly assembly = this.GetType().GetTypeInfo().Assembly;
            ExpandButton.Source = ImageSource.FromResource($"{path}expand_arrow.png", assembly);
            HideButton.Source = ImageSource.FromResource($"{path}hide_arrow.png", assembly);
            ExploreButton.Source = ImageSource.FromResource($"{path}explore.png", assembly);
            HomeButton.Source = ImageSource.FromResource($"{path}home.png", assembly);
            SettingsButton.Source = ImageSource.FromResource($"{path}settings.png", assembly);
        }

        async void RevealBtn_Clicked(System.Object s, System.EventArgs e)
        {
            await ExpandButton.TranslateTo(deviceWidth + 10, 0, 1000, Easing.SpringOut);
            await Task.WhenAll(
                    ExploreButton.FadeTo(100, 1000, Easing.CubicIn),
                    HomeButton.FadeTo(100, 1000, Easing.CubicIn),
                    SettingsButton.FadeTo(100, 1000, Easing.CubicIn)
                    );
            await HideButton.FadeTo(100, 500, Easing.Linear);
            ExpandButton.Opacity = 0;
            await ExpandButton.TranslateTo(0, 0, 0);
        }

        async void HideBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            await SettingsButton.FadeTo(0, 200, Easing.Linear);
            await HomeButton.FadeTo(0, 200, Easing.Linear);
            await ExploreButton.FadeTo(0, 200, Easing.Linear);
            await HideButton.TranslateTo(-deviceWidth - 10, 0, 1000, Easing.SpringOut);
            await ExpandButton.FadeTo(100, 500, Easing.Linear);
            HideButton.Opacity = 0;
            await HideButton.TranslateTo(0, 0, 0);
        }

    }
}