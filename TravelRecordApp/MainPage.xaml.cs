﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void LoginHandle_Clicked(object sender, System.EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if (isEmailEmpty || isPasswordEmpty) 
            {
                
            }
            else
            {
                Navigation.PushAsync(new HomePage());
            }
        }
    }
}
