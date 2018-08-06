using System;
using System.Windows.Input;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModal.Commands
{
    public class PostCommnad : ICommand 
    {
        public PostCommnad(NewTravelVM viewModel)
        {
            this.viewModel = viewModel;
        }

        NewTravelVM viewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var post = (Post)parameter;
            if (post != null)
            {
                if (string.IsNullOrEmpty(post.Experience))
                {
                    return false;
                }

                if (post.Venue != null) 
                {
                    return true;
                    
                }
                return false;
            }
            return false;
        }

        public void Execute(object parameter)
        {

            var post = (Post)parameter;
            viewModel.PublishPost(post);
        }
    }
}
