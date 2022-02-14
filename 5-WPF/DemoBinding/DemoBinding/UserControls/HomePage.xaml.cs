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
using DemoBinding.ApiData;
using DemoBinding.Dtos;
using DemoBinding.Utils;
using DemonBinding.Models;
using Polly;

namespace DemoBinding.UserControls
{
    /// <summary>
    /// Logique d'interaction pour HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {
        private readonly IDataManager<UserModel, UserDto> _userDataManager
            = ((App)Application.Current).UserDataManager;


        public INavigator Navigator { get; set; } = ((App)Application.Current).Navigator;
        public UsersList UsersList { get; set; } = new UsersList();


        public Policy Policy { get; set; } = Policy.Handle<Exception>().WaitAndRetry(new[]
        {
            TimeSpan.FromSeconds(5),
            TimeSpan.FromSeconds(10),
            TimeSpan.FromSeconds(30)
        });

        public HomePage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new UserModel() { Name = TbUserName.Text };

            UsersList.Users.Add(newUser);
            await _userDataManager.Add(newUser);
            //UsersList.Users = new ObservableCollection<UserModel>();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UsersList.IsVisible = !UsersList.IsVisible;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUser();
        }

        public async void LoadUser()
        {
            /*await Policy.Execute(async () =>
            {*/
            var userModels = await _userDataManager.GetAll();
            UsersList.Users = new ObservableCollection<UserModel>(userModels);
            UsersList.Users.Add(new AdminModel());
            //});
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (Navigator.CanGoBack())
            {
                Navigator.Back();
            }
        }
    }
}
