using System;
using System.Collections.Generic;
using System.Linq;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();


             
            var locator = CrossGeolocator.Current;

            //locator.PositionChanged += Locator_PositionChanged;
            //await locator.StartListeningAsync((new System.TimeSpan(0)), 100);

            var position = await locator.GetPositionAsync();

            var center = new Xamarin.Forms.Maps.Position(position.Latitude,
                                                         position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 2, 2);
            locationsMap.MoveToRegion(span);


            var posts = await Post.Read();
            DisplayInMap(posts);
        }

        protected async override void OnDisappearing()
        {
            base.OnDisappearing();
            var locator = CrossGeolocator.Current;
            locator.PositionChanged -= Locator_PositionChanged;

            await locator.StopListeningAsync();
        }

        private void DisplayInMap(List<Post> posts)
        {
            foreach(var post in posts) 
            {
                try
                {
                    var position = new Xamarin.Forms.Maps.Position(post.Latitude, post.Longitude);
                    var pin = new Xamarin.Forms.Maps.Pin()
                    {
                        Type = Xamarin.Forms.Maps.PinType.SavedPin,
                        Position = position,
                        Label = post.VenueName,
                        Address = post.Address
                    };
                    locationsMap.Pins.Add(pin);
                }
                catch
                {
                    
                }
            }
        }

        private void Locator_PositionChanged(object sender, PositionEventArgs e)
        {
            /*
             * 
            var center = new Xamarin.Forms.Maps.Position(e.Position.Latitude,
                                                         e.Position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 2, 2);
            locationsMap.MoveToRegion(span);
            
            */
        }
    }
}
