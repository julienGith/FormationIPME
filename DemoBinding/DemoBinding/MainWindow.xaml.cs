using AutoMapper;
using DemoBinding.ApiData;
using DemoBinding.Dtos;
using DemoBinding.Entities;
using DemoBinding.Persistance;
using DemonBinding.Models;
using Polly;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DemoBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDataManager<UserModel,UserDto> _userDataManager
            = ((App)Application.Current).UserDataManager;

        public UsersList UsersList { get; set; } = new UsersList();


        public Policy Policy { get; set; } = Policy.Handle<Exception>().WaitAndRetry(new[]
                                                                        {
                                                                            TimeSpan.FromSeconds(5),
                                                                            TimeSpan.FromSeconds(10),
                                                                            TimeSpan.FromSeconds(30)
                                                                        });

        public MainWindow()
        {
            InitializeComponent();
            DataContext = UsersList;       
            // ListUser.ItemsSource = Users;
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
            //});
        }
    }
}
