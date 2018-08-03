using System;
using System.Collections.Generic;
using TravelRecordApp.ViewModal;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class HomePage : TabbedPage
    {
        HomeVM viewModel;

        public HomePage()
        {
            InitializeComponent();
            viewModel = new HomeVM();
            BindingContext = viewModel;
        }

        void AddHandle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewTravelPage());
        }
    }
}
