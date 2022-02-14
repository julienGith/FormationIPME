using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZooWpf.ZooModels;
using ZooWpf.ZooModels.ViewModel;
using ZooWpf.ZooRepo;

namespace ZooWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IZooFakeRepo _zooFakeRepo;
        private AnimalViewModel _animalViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _zooFakeRepo = ((App)Application.Current)._zooFakeRepo;
            _animalViewModel = new AnimalViewModel();
            DataContext = _animalViewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var animals = _zooFakeRepo.GetAllAnimals();
            _animalViewModel.Animals = new ObservableCollection<Animal>(animals);
        }
    }
}
