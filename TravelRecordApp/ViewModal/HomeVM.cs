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

        public void Navigate()
        {
           // navigationCommand.   
        }
    }
}
