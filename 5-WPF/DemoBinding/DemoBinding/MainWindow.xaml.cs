using AutoMapper;
using DemoBinding.Entities;
using DemoBinding.Persistance;
using DemonBinding.Models;
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
        private readonly IGenericRepository<UserEntity> _userRepository
            = ((App)Application.Current).UserRepository;

        private readonly IMapper _mapper
          = ((App)Application.Current).Mapper;

        public UsersList UsersList { get; set; } = new UsersList();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = UsersList;

            var userModels = _mapper.Map<IEnumerable<UserModel>>(_userRepository.GetAll());
            UsersList.Users = new ObservableCollection<UserModel>(userModels);
            // ListUser.ItemsSource = Users;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new UserModel() { Name = TbUserName.Text };
            var userEntity = _mapper.Map<UserEntity>(newUser);
            _userRepository.Add(userEntity);
            UsersList.Users.Add(newUser);
            //UsersList.Users = new ObservableCollection<UserModel>();
        }

        
    }
}
