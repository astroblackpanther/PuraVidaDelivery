using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PuraVidaDelivery
{
    public partial class Onboarding_1 : ContentPage
    {
        public Onboarding_1()
        {
            InitializeComponent();

            // Hide the navigation bar
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            // Navigate to the Onboarding_2 page
            await Navigation.PushAsync(new Onboarding_2());
        }
    }
}