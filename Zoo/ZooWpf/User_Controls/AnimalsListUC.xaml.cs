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

namespace ZooWpf.User_Controls
{
    /// <summary>
    /// Interaction logic for AnimalsListUC.xaml
    /// </summary>
    public partial class AnimalsListUC : UserControl
    {
        private static readonly DependencyProperty _animalsProperty = DependencyProperty.Register("Animals", typeof(ObservableCollection<Animal>), typeof(AnimalsListUC));
        private ObservableCollection<Animal> _animals;
        public Animal SelectedAnimal;
        public ObservableCollection<Animal> Animals
        {
            get { return GetValue(_animalsProperty) as ObservableCollection<Animal>; }
            set
            {
                if (_animals != value)
                {
                    SetValue(_animalsProperty, value);
                }
            }
        }

        public AnimalsListUC()
        {
            InitializeComponent();
        }
    }
}
