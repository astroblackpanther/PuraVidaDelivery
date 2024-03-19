using System;
using Xamarin.Forms;

namespace PuraVidaDelivery
{
    public partial class Onboarding_2 : ContentPage
    {
        public Onboarding_2()
        {
            InitializeComponent();

            // Hide the navigation bar
            NavigationPage.SetHasNavigationBar(this, false);

        }

        private async void NextButton1_Clicked(object sender, EventArgs e)
        {
            // Navigate to the next page (Onboarding_3)
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}