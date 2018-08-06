using System;
using System.Collections.Generic;
using System.Linq;
using Plugin.Geolocator;
using SQLite;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModal;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class NewTravelPage : ContentPage
    {

        NewTravelVM viewModel;


        public NewTravelPage()
        {
            InitializeComponent();

            viewModel = new NewTravelVM();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;

            var position = await locator.GetPositionAsync();

            var venues = await Venue.GetVenues(position.Latitude, position.Longitude);

            venueListView.ItemsSource = venues;
        }

    }
}
