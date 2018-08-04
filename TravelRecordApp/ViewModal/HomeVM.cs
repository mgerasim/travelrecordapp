using System;
using TravelRecordApp.ViewModal.Commands;

namespace TravelRecordApp.ViewModal
{
    public class HomeVM
    {
        public NavigationCommand navigationCommand { get; set; }
        public HomeVM()
        {
            navigationCommand = new NavigationCommand(this);
        }

        public async void Navigate()
        {
            await App.Current.MainPage.Navigation.PushAsync(new NewTravelPage());  
        }
    }
}
