using System;
using System.Collections.Generic;
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
using DemoBinding.UserControls;
using DemoBinding.Utils;

namespace DemoBinding
{
    /// <summary>
    /// Logique d'interaction pour LoginPage.xaml
    /// </summary>
    public partial class LoginPage : UserControl
    {
        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(typeof(HomePage));
        }
    }
}
