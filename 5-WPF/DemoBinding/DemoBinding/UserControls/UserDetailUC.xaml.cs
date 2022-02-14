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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DemoBinding.Annotations;
using DemonBinding.Models;

namespace DemoBinding.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UserDetailUC.xaml
    /// </summary>
    public partial class UserDetailUC : UserControl 
    {

        private static readonly DependencyProperty CurrentUserProperty = 
            DependencyProperty.Register("CurrentUser",typeof(UserModel),typeof(UserDetailUC));

        private UserModel currentUser;
        public UserModel CurrentUser
        {
            get { return GetValue(CurrentUserProperty) as UserModel; }
            set
            {
                if (currentUser != value)
                {
                   SetValue(CurrentUserProperty , value);
                }
            }
        }


        public UserDetailUC()
        {
            InitializeComponent();
        }

    }
}
