using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var postTable = await Post.Read();

            var categoriesCount = Post.PostCategories(postTable);

               
            categoriesListView.ItemsSource = categoriesCount;

            postCountLabel.Text = postTable.Count.ToString();



        }
    }
}
