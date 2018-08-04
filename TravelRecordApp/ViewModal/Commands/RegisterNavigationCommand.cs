using System;
using System.Windows.Input;

namespace TravelRecordApp.ViewModal.Commands
{
    public class RegisterNavigationCommand : ICommand
    {
        private MainVM viewModel;

        public RegisterNavigationCommand(MainVM viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.Navigate();
        }
    }
}
