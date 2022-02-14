using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWpf.ZooModels.ViewModel
{
    public class AnimalViewModel : ObservableObject
    {
        private ObservableCollection<Animal> _animals;

        public ObservableCollection<Animal> Animals
        {
            get { return _animals; }
            set { _animals = value; OnNotifyPropertyChanged(); }
        }
        private Animal _currentAnimal;

        public Animal CurrentAnimal 
        {
            get { return _currentAnimal; }
            set { _currentAnimal = value; OnNotifyPropertyChanged(); }
        }

    }
}
