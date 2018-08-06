using System;
using System.ComponentModel;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModal.Commands;

namespace TravelRecordApp.ViewModal
{
    public class NewTravelVM : INotifyPropertyChanged
    {
        
        public PostCommnad PostCommnad { get; set; }

        private Post post;
        public Post Post { 
            get
            {
                return post;
            }
            set
            {
                post = value;
                OnPropertyChanged("Post");
            }
        }

        private string experience;

        public string Experience
        {
            get
            {
                return experience;
            }
            set
            {
                experience = value;
                Post = new Post()
                {
                    Experience = this.Experience,
                    Venue = this.venue
                };
                OnPropertyChanged("Experience");
            }
        }

        private Venue venue;

        public Venue Venue
        {
            get
            {
                return venue;
            }
            set
            {
                venue = value;
                Post = new Post()
                {
                    Experience = this.Experience,
                    Venue = this.venue
                };
                OnPropertyChanged("Venue");
            }
        }


        public NewTravelVM()
        {
            PostCommnad = new PostCommnad(this);
            Post = new Post();
            Venue = new Venue();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public async void PublishPost(Post post)
        {
            try
            {
                
                Post.Insert(post);
                await App.Current.MainPage.DisplayAlert("Success", "Experience successfully inserted", "Ok");

            }
            catch (NullReferenceException ex)
            {
                await App.Current.MainPage.DisplayAlert("Fail", "Experience fialfully inserted", "Ok");


            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Fail", "Experience fialfully inserted", "Ok");
            }

        }
    }
}
