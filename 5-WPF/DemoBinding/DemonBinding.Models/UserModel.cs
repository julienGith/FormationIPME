namespace DemonBinding.Models
{
    public class UserModel : ObservableObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        private DateTime birthDate;

        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                if (birthDate != value)
                {
                    birthDate = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

    }
}