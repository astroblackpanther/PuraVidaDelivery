using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShoppingList
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Simular la simulacion
            await SimulateInitializationAsync();

            // Navegar a la pagina de StartPage despues que la carga esta completa
            await Navigation.PushAsync(new StartPage());
        }

        private async Task SimulateInitializationAsync()
        {

            for (int progress = 0; progress < 100; progress += 5)
            {
                LogoImage.TranslationY = -50;
                ProgressBar.Progress = progress / 100.0; // Actualizacion de la barra de progreso
                await Task.Delay(250); // Simulate a delay
            }

            LogoImage.TranslationY = 0; // Reset the logo position
        }
    }
}
