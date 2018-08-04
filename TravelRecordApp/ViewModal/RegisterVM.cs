using System;
using System.ComponentModel;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModal.Commands;

namespace TravelRecordApp.ViewModal
{
    public class RegisterVM : INotifyPropertyChanged
    {
        private string email;

        public string Email 
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfirmPassword = this.confirmPassword
                };
                OnPropertyChanged("Email");
            }
        }

        private string password;

        public string Password
        {
            get 
            {
                return password;
            }
            set
            {
                password = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfirmPassword = this.confirmPassword
                };
                OnPropertyChanged("Password");
            }
        }

        private string confirmPassword;

        public string ConfirmPassword
        {
            get
            {
                return confirmPassword;
            }
            set
            {
                confirmPassword = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfirmPassword = this.confirmPassword
                };
                OnPropertyChanged("ConfirmPassword");
            }
        }

        private User user;

        public User User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public RegisterCommand RegisterCommand { get; set; }

        public RegisterVM()
        {
            RegisterCommand = new RegisterCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) 
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Register(User user)
        {
            User.Register(user);
        }
    }
}
