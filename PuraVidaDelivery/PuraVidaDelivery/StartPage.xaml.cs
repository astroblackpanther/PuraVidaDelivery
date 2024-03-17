using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShoppingList
{
    public partial class StartPage : ContentPage, INotifyPropertyChanged
    {
        private bool isLoading = false;
        private int currentIndex = 0;
        private ObservableCollection<string> imageSources = new ObservableCollection<string>

        {
            "Slide1.png",
            "Slide2.png",
            "Slide3.png",

        };

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsLoading
        {
            get { return isLoading; }
            set
            {
                if (isLoading != value)
                {
                    isLoading = value;
                    OnPropertyChanged(nameof(IsLoading));
                }
            }
        }

        public string CurrentImageSource => imageSources[currentIndex];

        public StartPage()
        {
            InitializeComponent();


            // Inicializar el UI con la primera imagen
            OnPropertyChanged(nameof(CurrentImageSource));

            // Adjuntar el click event handler al botton de "Empieza tu compra"
            ContinueButton.Clicked += OnContinueClicked; ;
        }

        private async Task LoadDataAsync()
        {
            // Simular la carga por unos segundos
            await Task.Delay(5000);

            // Navegar a la pagina de Login
            Device.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            });
        }

        private async void OnContinueClicked(object sender, EventArgs e)
        {
            try
            {
                IsLoading = true;

                await Task.Delay(2000);

                await Navigation.PushAsync(new LoginPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
