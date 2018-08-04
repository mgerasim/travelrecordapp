﻿using System;
using System.ComponentModel;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModal.Commands;

namespace TravelRecordApp.ViewModal
{
    public class MainVM : INotifyPropertyChanged
    {
        private User user;

        public User User {
            get {
                return user;
            }
            set {
                user = value;
                OnPropertyChanged("User");
            }
        }
        public RegisterNavigationCommand RegisterNavigationCommand { get; set; }
        public LoginCommand LoginCommand { get; set; }

        private string email;

        public string Email
        {
            get {
                return email;
            }
            set {
                email = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Email");
            }
        }

        private string password;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Password
        {
            get{
                return password;
            }
            set {
                password = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Password");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (propertyName != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainVM()
        {
            LoginCommand = new LoginCommand(this);
            RegisterNavigationCommand = new RegisterNavigationCommand(this);
        }

        public async void Login()
        {
            bool canLogin = await User.Login(User.Email, User.Password);
            if (canLogin)
            {
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Try again", "Ok");

            }
        }

        public async void Navigate()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
    }
}
