using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ManagmentEmploye
{
    /// <summary>
    /// Логика взаимодействия для AddView.xaml
    /// </summary>
    public partial class AddView : Window
    {
        public AddView()
        {
            InitializeComponent();
        }

        private void CreateButton(object sender, RoutedEventArgs e)
        {
            var client = new RestClient("http://f0772709.xsph.ru/API");
            var request = new RestRequest("/SetNewEmploye.php");
            request.AddParameter("FName", FirstNameBox.Text);
            request.AddParameter("LName", LastnameBox.Text);
            request.AddParameter("Age", AgeBox.Text);
            request.AddParameter("Position", PositionBox.Text);
            request.AddParameter("Salary", SalaryBox.Text);
            RestResponse response = client.Execute(request);


            this.Close();
        }

        private void Close(object sender, RoutedEventArgs e)
        {

        }
    }
}
