using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        string _role;
        int _caphId;
        public MainPage(string role, int caphId)
        {
            InitializeComponent();
            update();
            _role = role;
            _caphId = caphId;
        }

        public void update(string type = "asc")
        {
            ListEmployees.ItemsSource = null;
            if (type == "asc")
                ListEmployees.ItemsSource = ConnectionClass.connect.Employe.Where(z => z.FullName.ToLower().Contains(TxtSearch.Text)).OrderBy(z => z.FullName).ToList();
            else if (type == "desc")
                ListEmployees.ItemsSource = ConnectionClass.connect.Employe.Where(z => z.FullName.ToLower().Contains(TxtSearch.Text)).OrderByDescending(z => z.FullName).ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_role == "зав" || _role == "инженер")
            {
                NavigationService.Navigate(new AddPage(_role, _caphId));
            }
            else
                MessageBox.Show("Кто ты, воин?");
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_role == "зав" || _role == "инженер")
            {
                Employe selectedEm = ListEmployees.SelectedItem as Employe;
                if (selectedEm != null)
                {
                    if ((_role == "зав" && selectedEm.CaphID == _caphId) || _role == "инженер")
                        NavigationService.Navigate(new EditPage(selectedEm, _role, _caphId));
                    else
                        MessageBox.Show("Вы можете менять данные сотрудников только своей кафедры!");
                }
                else
                {
                    MessageBox.Show("Выберите сотрудника!");
                }
            }
            else
                MessageBox.Show("Кто ты, воин?");
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_role == "зав" || _role == "инженер")
            {
                Employe selectedEm = ListEmployees.SelectedItem as Employe;
                if (selectedEm != null)
                {
                    if ((_role == "зав" && selectedEm.CaphID == _caphId) || _role == "инженер")
                    {
                        Teacher tr = new Teacher();
                        tr = ConnectionClass.connect.Teacher.Where(z => z.EmpID == selectedEm.ID).FirstOrDefault();
                        ConnectionClass.connect.Teacher.Remove(tr);
                        ConnectionClass.connect.Employe.Remove(selectedEm);
                        ConnectionClass.connect.SaveChanges();
                        update();
                    }
                    else
                        MessageBox.Show("Вы можете удалять сотрудников только своей кафедры!");
                }
                else
                {
                    MessageBox.Show("Выберите сотрудника!");
                }
            }
            else
                MessageBox.Show("Кто ты, воин?");
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            update();
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            update();   
        }

        private void SortRev_Click(object sender, RoutedEventArgs e)
        {
            update("desc");
        }

        private void CaphBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CaphPage(_role, _caphId));
        }

        private void DiscBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DiscPage(_role, _caphId));
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
