using System;
using System.Collections.Generic;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (passwordEntry.Text == confirmPasswordEntry.Text)
            {
                User user = new User()
                {
                    Email = emailEntry.Text,
                    Password = passwordEntry.Text
                };

                User.Register(user);
            }
            else
            {
                DisplayAlert("Error", "Password not match", "Ok");
            }
        }
    }
}
