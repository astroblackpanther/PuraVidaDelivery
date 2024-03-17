using ShoppingList.Data;
using ShoppingList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BtnRegister.Clicked += BtnRegister_Clicked;
        }

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            string Key = ((App)App.Current).KEY_USER;
            DateTime Today = DateTime.Now;
            User Register = new User() { Mail = TxtEmail.Text, Password = PasswordHash(TxtPass.Text), Active = 0, SingUpDate = Today.ToString("dd/MM/yyyy") };
            string Result = await FbQueries.RegisterUser(Register);
            Preferences.Set(Key, Result);
            await ((NavigationPage)this.Parent).PushAsync(new MainPage());
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