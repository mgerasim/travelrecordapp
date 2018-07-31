using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);

            iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.logo.ico", assembly);
        }

        private async void LoginHandle_Clicked(object sender, System.EventArgs e)
        {
            
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if (isEmailEmpty || isPasswordEmpty) 
            {
                var assembly = typeof(MainPage);
                iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.logo.ico", assembly);                
            }
            else
            {
                var user = (await App.MobileService.GetTable<User>().Where(u => u.Email == emailEntry.Text).ToListAsync()).FirstOrDefault();

                if (user != null)
                {
                    App.user = user;
                    if (user.Password == passwordEntry.Text) 
                    {
                        await Navigation.PushAsync(new HomePage());

                    }
                    else
                    {
                        await DisplayAlert("Error", "Password or Email are incorrect", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "There was an error logging are you in", "Ok");
                }
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
