using AutoMapper;
using DemoBinding.Entities;
using DemoBinding.Persistance;
using System.Windows;

namespace DemoBinding
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IGenericRepository<UserEntity> UserRepository { get; } 
            = new FakeGenericRepository<UserEntity>();


        public IMapper Mapper { get; }

        public App()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(App)));
            Mapper = new Mapper(configuration); 
        }
    }
}
