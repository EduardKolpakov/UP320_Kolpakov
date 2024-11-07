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
    /// Логика взаимодействия для DiscPage.xaml
    /// </summary>
    public partial class DiscPage : Page
    {
        string _role;
        int _caphId;
        public DiscPage(string role, int caphId)
        {
            InitializeComponent();
            _role = role;
            _caphId = caphId;
            update();
        }

        public void update(string type = "asc")
        {
            ListDiscs.ItemsSource = null;
            if (type == "asc")
                ListDiscs.ItemsSource = ConnectionClass.connect.Disciple.Where(z => z.Name.ToLower().Contains(TxtSearch.Text)).OrderBy(z => z.Name).ToList();
            else if (type == "desc")
                ListDiscs.ItemsSource = ConnectionClass.connect.Disciple.Where(z => z.Name.ToLower().Contains(TxtSearch.Text)).OrderByDescending(z => z.Name).ToList();
        }

        private void CaphBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CaphPage(_role, _caphId));
        }

        private void EmpBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage(_role, _caphId));
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            update();
        }

        private void SortRev_Click(object sender, RoutedEventArgs e)
        {
            update("desc");
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DiscAddPage(_role, _caphId));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            Disciple z = ListDiscs.SelectedItem as Disciple;
            if (z != null)
                ConnectionClass.connect.Disciple.Remove(z);
            else
                MessageBox.Show("Выберите дисциплину!");
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Disciple z = ListDiscs.SelectedItem as Disciple;
            if (z != null)
                NavigationService.Navigate(new DiscEditPage(z, _role, _caphId));
            else
                MessageBox.Show("Выберите дисциплину!");
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
    }
}
