using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModal;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class HistoryPage : ContentPage
    {
        HistoryVM viewModel;

        public HistoryPage()
        {
            InitializeComponent();

            viewModel = new HistoryVM();

            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.UpdatePosts();
        }
    }
}
