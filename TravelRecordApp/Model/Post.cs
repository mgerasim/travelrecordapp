using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using System.Linq;
using System.ComponentModel;

namespace TravelRecordApp.Model
{
    public class Post : INotifyPropertyChanged
    {
        private string id;

        public string Id { 
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
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
                OnPropertyChanged("Experience");
            }
        }

        private string venueName;

        public string VenueName { 
            get
            {
                return venueName;
            }
            set
            {
                venueName = value;
                OnPropertyChanged("VenueName");
            }
        }

        private string categoryId;

        public string CategoryId { 
            get
            {
                return categoryId;
            }
            set
            {
                categoryId = value;
                OnPropertyChanged("CategoryId");
            }
        }
        private string categoryName;

        public string CategoryName { 
            get
            {
                return categoryId;
            }
            set
            {
                categoryId = value;
                OnPropertyChanged("CategoryName");
            }
        }

        private string address;

        public string Address { 
            get
            {
                return address;   
            }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        private double latitube;

        public double Latitude { 
            get
            {
                return latitube;
            }
            set
            {
                latitube = value;
                OnPropertyChanged("Latitube");
            }
        }

        private double longitube;

        public double Longitude { 
            get
            {
                return longitube;
            }
            set
            {
                longitube = value;
                OnPropertyChanged("Longitube");
            }
        }

        private int distance;

        public int Distance { 
            get
            {
                return distance;     
            }
            set
            {
                distance = value;
                OnPropertyChanged("Distance");
            }
        }
        private string userID;

        public string UserID { 
            get
            {
                return userID;
                
            }
            set
            {
                userID = value;
                OnPropertyChanged("UserID");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Post()
        {
        }

        public static async void Insert(Post post)
        {
            await App.MobileService.GetTable<Post>().InsertAsync(post);
        }

        public static async Task<List<Post>> Read()
        {
            var posts = await App.MobileService.GetTable<Post>().Where(p => p.UserID == App.user.Id).ToListAsync();
            return posts;
        }

        public static Dictionary<string, int> PostCategories(List<Post> posts)
        {
            var categories = (from p in posts
                              orderby p.CategoryId
                              select p.CategoryName).Distinct().ToList();

            Dictionary<String, Int32> categoriesCount = new Dictionary<string, int>();

            foreach (var category in categories)
            {
                if (category == null)
                {
                    continue;
                }
                var count = (from post in posts
                             where post.CategoryName == category
                             select post).ToList().Count;


                categoriesCount.Add(category, count);
            }

            return categoriesCount;
        }

        private void OnPropertyChanged(string propertyName)
        {

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
