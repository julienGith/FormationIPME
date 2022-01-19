using System.Collections.ObjectModel;
namespace DemonBinding.Models
{
    public class UsersList : ObservableObject
    {
        private ObservableCollection<UserModel> users;

        private UserModel currentUser;

        public UserModel CurrentUser
        {
            get { return currentUser; }
            set
            {
                if (currentUser != value)
                {
                    currentUser = value;
                    OnNotifyPropertyChanged();
                }
            }
        }


        public ObservableCollection<UserModel> Users
        {
            get { return users; }
            set
            {
                if (users != value)
                {
                    users = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
    }
}
