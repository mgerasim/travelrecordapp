﻿using System;
using System.Windows.Input;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModal.Commands
{
    public class LoginCommand : ICommand
    {
        public LoginCommand(MainVM viewModel)
        {
            ViewModel = viewModel;
        }

        public MainVM ViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var user = (User)parameter;

            if (user == null)
                return false;
            
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password)) 
            {
                return false;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.Login();
        }
    }
}
