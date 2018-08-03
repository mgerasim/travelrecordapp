using System;
using System.Collections.Generic;
using System.Linq;
using Plugin.Geolocator;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class NewTravelPage : ContentPage
    {
        Post post;
        public NewTravelPage()
        {
            InitializeComponent();

            post = new Post();
            containerStackLayout.BindingContext = post;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;

            var position = await locator.GetPositionAsync();

            var venues = await Venue.GetVenues(position.Latitude, position.Longitude);

            venueListView.ItemsSource = venues;
        }

        async void SaveHandle_Clicked(object sender, System.EventArgs e)
        {
            try
            {

                var selectedVenue = venueListView.SelectedItem as Venue;
                var firstCategory = selectedVenue.categories.FirstOrDefault();

                post.CategoryId = firstCategory.id;
                post.CategoryName = firstCategory.name;
                post.Address = selectedVenue.location.address;
                post.Distance = selectedVenue.location.distance;
                post.Latitude = selectedVenue.location.lat;
                post.Longitude = selectedVenue.location.lng;
                post.VenueName = selectedVenue.name;
                post.UserID = App.user.Id;




                /*

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Post>();
                    int rows = conn.Insert(post);

                    if (rows > 0)
                        DisplayAlert("Success", "Experience successfully inserted", "Ok");
                    else
                        DisplayAlert("Fail", "Experience fialfully inserted", "Ok");
                }
                */
                Post.Insert(post);
                await DisplayAlert("Success", "Experience successfully inserted", "Ok");

            }
            catch(NullReferenceException ex)
            {
                await DisplayAlert("Fail", "Experience fialfully inserted", "Ok");


            }
            catch(Exception ex) 
            {
                await DisplayAlert("Fail", "Experience fialfully inserted", "Ok");
            }

        }
    }
}
