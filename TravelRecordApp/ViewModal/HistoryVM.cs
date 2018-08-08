using System;
using System.Collections.ObjectModel;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModal
{
    public class HistoryVM
    {
        public HistoryVM()
        {
            Posts = new ObservableCollection<Post>();
        }

        public ObservableCollection<Post> Posts;

        public async void UpdatePosts()
        {
            Posts.Clear();

            var posts = await Post.Read();

            if (posts != null)
            {
                foreach (var post in posts)
                {
                    Posts.Add(post);
                }
            }
        }
    }
}
