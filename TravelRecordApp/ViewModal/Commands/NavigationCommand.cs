using System;
using System.Windows.Input;

namespace TravelRecordApp.ViewModal.Commands
{
    public class NavigationCommand : ICommand
    {
        public NavigationCommand(HomeVM homeVM)
        {
            homeViewModel = homeVM;
        }

        public HomeVM homeViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            homeViewModel.Navigate();
        }
    }
}
