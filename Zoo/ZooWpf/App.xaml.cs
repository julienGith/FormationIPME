using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ZooWpf.ZooRepo;

namespace ZooWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IZooFakeRepo _zooFakeRepo;
        public App()
        {
            _zooFakeRepo = new ZooFakeRepo();
        }
    }
}
