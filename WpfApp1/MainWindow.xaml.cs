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

using ConsoleApp1;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ingatlanContext AppdDbContext { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AppdDbContext = new ingatlanContext();
            AppdDbContext.Sellers.Load();
            lstNames.ItemsSource = AppdDbContext.Sellers.Local.ToObservableCollection();
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            //var data = AppdDbContext.Realestates.Local.ToObservableCollection();
            if(lstNames.SelectedItem != null)
            {
                var selectedSeller = lstNames.SelectedItem as ConsoleApp1.Models.Seller;
                var selectedData = AppdDbContext.Realestates.Where(c => c.Seller.Name == selectedSeller.Name).ToList<Realestate>();
                adNumberLabel.Content = selectedData.Count();
            }
            else
            {
                MessageBox.Show("Error", "Select a seller first!");
            }
        }
    }
}