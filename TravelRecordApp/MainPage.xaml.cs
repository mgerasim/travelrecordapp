using System;
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

            var assembly = typeof(MainPage);

            iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.logo.ico", assembly);
        }

        void LoginHandle_Clicked(object sender, System.EventArgs e)
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
                Navigation.PushAsync(new HomePage());
            }
        }
    }
}
