using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        void AddHandle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewTravelPage());
        }
    }
}
