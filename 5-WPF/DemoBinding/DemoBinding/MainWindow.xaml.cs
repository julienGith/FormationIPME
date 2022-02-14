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
using DemoBinding.UserControls;
using DemoBinding.Utils;

namespace DemoBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public INavigator Navigator { get; set; } = ((App) Application.Current).Navigator;
   
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this; 
            Navigator.NavigateTo(typeof(LoginPage));
        }

        

        private void GoBackClick(object sender, RoutedEventArgs e)
        {
            if (Navigator.CanGoBack())
            {
                Navigator.Back();
            }
        }
        
    }
}
