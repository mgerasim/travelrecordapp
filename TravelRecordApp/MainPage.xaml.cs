using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModal;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
        MainVM viewModel = new MainVM();
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);

            iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.logo.ico", assembly);

            BindingContext = viewModel;
        }


        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
