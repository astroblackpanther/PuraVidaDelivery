using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PuraVidaDelivery
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();

            // Hide the navigation bar
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Simulate initialization
            await SimulateInitializationAsync();

            // Navigate to the Onboarding_1 page after loading is complete
            await Navigation.PushAsync(new Onboarding_1());
        }

        private async Task SimulateInitializationAsync()
        {
            // Simulate initialization progress
            for (int progress = 0; progress <= 100; progress += 5)
            {
                ProgressBar.Progress = progress / 100.0; // Update the progress bar
                await Task.Delay(250); // Simulate a delay
            }
        }
    }
}
