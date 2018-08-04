﻿using System;
using System.Windows.Input;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModal.Commands
{
    public class RegisterCommand : ICommand
    {
        private RegisterVM viewModel;

        public RegisterCommand(RegisterVM viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            User user = (User)parameter;
            if (user != null)
            {
                if (user.Password == user.ConfirmPassword)
                {
                    if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            User user = (User)parameter;
            viewModel.Register(user);
        }
    }
}
