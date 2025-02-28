﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PuraVidaDelivery
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Set the main page to the splash page
            MainPage = new NavigationPage(new SplashPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}