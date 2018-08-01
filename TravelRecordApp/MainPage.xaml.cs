﻿using System;
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

            bool canLogin = await User.Login(emailEntry.Text, passwordEntry.Text);
            if (canLogin) 
            {
                await Navigation.PushAsync(new HomePage());
            }
            else 
            {
                await DisplayAlert("Error", "Try again", "Ok");
                
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
