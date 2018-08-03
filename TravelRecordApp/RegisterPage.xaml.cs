using System;
using System.Collections.Generic;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class RegisterPage : ContentPage
    {
        User user;
        public RegisterPage()
        {
            InitializeComponent();

            user = new User();

            containerStackLayout.BindingContext = user;

        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (passwordEntry.Text == confirmPasswordEntry.Text)
            {

                User.Register(user);
            }
            else
            {
                DisplayAlert("Error", "Password not match", "Ok");
            }
        }
    }
}
