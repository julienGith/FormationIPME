using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DemoBinding
{
    /// <summary>
    /// Logique d'interaction pour DemoVisualState.xaml
    /// </summary>
    public partial class DemoVisualState : Window, INotifyPropertyChanged
    {
        private RecState _recState;

        public RecState RecState
        {
            get { return _recState; }
            set
            {
                if (_recState != value)
                {
                    _recState = value;
                    OnPropertyChanged();
                }
            }
        }
    
        public DemoVisualState()
        {
            InitializeComponent();
            DataContext = this; 
        }

        /// <summary>
        /// Méthode qui change l'état de notre élément 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGoToSmall(object sender, RoutedEventArgs e)
        {
            RecState = RecState.Small; 
        }

        /// <summary>
        ///  Méthode qui change l'état de notre élément 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGoToLarge(object sender, RoutedEventArgs e)
        {
            RecState = RecState.Large;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnGoToVisible(object sender, RoutedEventArgs e)
        {
            RecState = RecState.Visible; 
        }

        private void OnGoToCollapsed(object sender, RoutedEventArgs e)
        {
            RecState = RecState.Collapsed;
        }
    }
}
