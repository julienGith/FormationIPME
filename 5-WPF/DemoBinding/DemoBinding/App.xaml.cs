using AutoMapper;
using DemoBinding.ApiData;
using DemoBinding.Dtos;
using DemoBinding.Entities;
using DemoBinding.Persistance;
using DemonBinding.Models;
using System.Net.Http;
using System.Windows;
using System.Windows.Navigation;
using DemoBinding.UserControls;
using DemoBinding.Utils;

namespace DemoBinding
{
    /// <summary>
    /// Interaction logic for App.xamlreé
    /// </summary>
    public partial class App : Application
    {
        private const string SERVER_URL = "https://localhost:7167"; 

        public HttpClient HttpClient { get; } = new HttpClient();

        public IDataManager<UserModel,UserDto> UserDataManager { get; } 

        public IMapper Mapper { get; }

        public INavigator Navigator { get; } = new Navigator();

        public App()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(App)));
            Mapper = new Mapper(configuration);
            UserDataManager = new UserDataManager(HttpClient, Mapper, SERVER_URL);
            
        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            Navigator.RegisterView(new LoginPage());
            Navigator.RegisterView(new HomePage());
        }
    }
}
