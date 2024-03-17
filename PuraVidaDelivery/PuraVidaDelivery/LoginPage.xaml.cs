using PuraVidaDelivery;
using ShoppingList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shopping
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private bool FirstAppear;
        public LoginPage()
        {
            InitializeComponent();
            BtnLogin.Clicked += BtnLogin_Clicked;
            BtnRegister.Clicked += BtnRegister_Clicked;
            FirstAppear = true;
        }

        private void BtnRegister_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new RegisterPage());
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            string Result = await FbQueries.Login(TxtEmail.Text, PasswordHash(TxtPass.Text));
            if (Result != null)
            {
                string Key = ((App)Application.Current).KEY_USER;
                Preferences.Set(Key, Result);
                await ((NavigationPage)this.Parent).PushAsync(new MainPage());
            }
        }

        protected override void OnAppearing()
        {
            if (FirstAppear)
            {
                int PagesCount = ((NavigationPage)this.Parent).Navigation.NavigationStack.Count;
                for (int i = 0; i < PagesCount - 1; i++)
                    ((NavigationPage)this.Parent).Navigation.RemovePage(((NavigationPage)this.Parent).Navigation.NavigationStack[0]);
                FirstAppear = false;
            }
        }

        private string PasswordHash(string Pass)
        {
            SHA1CryptoServiceProvider sHA1 = new SHA1CryptoServiceProvider();
            byte[] encrypted = sHA1.ComputeHash(Encoding.UTF8.GetBytes(Pass));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in encrypted)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

    }
}