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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UP320_Kolpakov.Model;

namespace UP320_Kolpakov.Pages
{
    /// <summary>
    /// Логика взаимодействия для CaphPage.xaml
    /// </summary>
    public partial class CaphPage : Page
    {
        string _role;
        int _caphId;
        public CaphPage(string role, int caphId)
        {
            InitializeComponent();
            _role = role;
            _caphId = caphId;
            update();
            
        }
        public void update(string type = "asc")
        {
            ListCaphs.ItemsSource = null;
            if (type == "asc")
                ListCaphs.ItemsSource = ConnectionClass.connect.Caphedra.Where(z => z.Name.ToLower().Contains(TxtSearch.Text)).OrderBy(z => z.Name).ToList();
            else if (type == "desc")
                ListCaphs.ItemsSource = ConnectionClass.connect.Caphedra.Where(z => z.Name.ToLower().Contains(TxtSearch.Text)).OrderByDescending(z => z.Name).ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_role == "зав" || _role == "инженер")
            {
                NavigationService.Navigate(new CaphAddPage(_role, _caphId));
            }
            else
            {
                MessageBox.Show("Кто ты, воин?");
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Caphedra z = ListCaphs.SelectedItem as Caphedra;
            if (z != null)
            {
                if ((_role == "зав" && _caphId == z.ID) || _role == "инженер")
                {
                    NavigationService.Navigate(new CaphEditPage(z, _role, _caphId));
                }
                else
                {
                    MessageBox.Show("Кто ты, воин?");
                }
            }
            else
            {
                MessageBox.Show("Выберите кафедру!");
            }
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            Caphedra z = ListCaphs.SelectedItem as Caphedra;
            if (z != null)
            {
                if ((_role == "зав" && _caphId == z.ID) || _role == "инженер")
                {
                    ConnectionClass.connect.Caphedra.Remove(z);
                    update();
                }
                else
                {
                    MessageBox.Show("Кто ты, воин?");
                }
            }
            else
            {
                MessageBox.Show("Выберите кафедру!");
            }
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            update();
        }

        private void SortRev_Click(object sender, RoutedEventArgs e)
        {
            update("desc");
        }

        private void EmpBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage(_role, _caphId));
        }

        private void Qr_Click(object sender, RoutedEventArgs e)
        {
            QrCodeWindow qrCodeWindow = new QrCodeWindow();
            qrCodeWindow.Show();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            update();
        }

        private void DiscBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DiscPage(_role, _caphId));
        }
    }
}
