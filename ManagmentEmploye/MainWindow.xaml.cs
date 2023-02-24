global using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
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

namespace ManagmentEmploye
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Employee> employees;
        public MainWindow()
        {
            InitializeComponent();
            GetEmployees();
        }

        private void Help(object sender, RoutedEventArgs e) => GetEmployees();

        private void GetEmployees()
        {
            var client = new RestClient("http://f0772709.xsph.ru/API");
            var request = new RestRequest("/GetEmployees.php");
            RestResponse response = client.Execute(request);
            string json = response.Content.ToString();
            employees = JsonSerializer.Deserialize<ObservableCollection<Employee>>(json);
            ListEmployee.ItemsSource = employees;
            foreach (var item in employees)
            {

            }
        }

        private void MinimazeButton(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            AddView addView = new AddView();
            addView.ShowDialog();
        }

        private void LeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            
            if (ListEmployee.SelectedItems.Count > 0)
            {
                Employee emp = (Employee)((Button)sender).DataContext;

                var client = new RestClient("http://f0772709.xsph.ru/API");
                var request = new RestRequest($"/RemoveEmploye.php?id={emp.Id}");
                WebClient webClient = new WebClient();
                request.AddParameter("id", emp.Id);
                client.Execute(request);
                ListEmployee.ItemsSource = null;
                ListEmployee.Items.Remove(emp);
                GetEmployees();
            }
        }
    }
}
