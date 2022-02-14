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

namespace ZooWpf.User_Controls
{
    /// <summary>
    /// Interaction logic for AnimalDetailsUC.xaml
    /// </summary>
    public partial class AnimalDetailsUC : UserControl
    {
        private static readonly DependencyProperty _currentAnimalProperty = DependencyProperty.
            Register("CurrentAnimal", typeof(Animal), typeof(AnimalDetailsUC));
        private Animal _currentAnimal;
        public Animal CurrentAnimal
        {
            get { return GetValue(_currentAnimalProperty) as Animal; }
            set
            {
                if (_currentAnimal != value)
                {
                    SetValue(_currentAnimalProperty, value);
                }
            }
        }

        public AnimalDetailsUC()
        {
            InitializeComponent();
        }
    }
}
