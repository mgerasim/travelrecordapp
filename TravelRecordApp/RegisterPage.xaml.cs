using System;
using System.Collections.Generic;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModal;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class RegisterPage : ContentPage
    {
        User user;

        RegisterVM viewModel;

        public RegisterPage()
        {
            InitializeComponent();


            viewModel = new RegisterVM();

            BindingContext = viewModel;

        }


    }
}
