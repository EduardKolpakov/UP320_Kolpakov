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
            FilterBox.Items.Add("Имя");
            FilterBox.Items.Add("Позиция");
            FilterBox.Items.Add("ID");
            FilterBox.Items.Add("Ранг");
            FilterBox.Items.Add("Степень");
            FilterBox.SelectedIndex = 0;
            SortBox.Items.Add("ID");
            SortBox.Items.Add("ID (В обратном)");
            SortBox.Items.Add("Имя");
            SortBox.Items.Add("Имя (В обратном)");
            SortBox.Items.Add("Позиция");
            SortBox.Items.Add("Позиция (В обратном)");
            SortBox.Items.Add("Зарплата");
            SortBox.Items.Add("Зарплата (В обратном)");
            SortBox.SelectedIndex = 0;
            update();
            _role = role;
            _caphId = caphId;
        }

        public void update()
        {
            ListEmployees.ItemsSource = null;
            if (SortBox.SelectedIndex == 0)
            {
                ListEmployees.ItemsSource = ConnectionClass.connect.Employes.OrderBy(z => z.ID).ToList();
            }
            if (SortBox.SelectedIndex == 1)
            {
                ListEmployees.ItemsSource = ConnectionClass.connect.Employes.OrderByDescending(z => z.ID).ToList();
            }
            if (SortBox.SelectedIndex == 2)
            {
                ListEmployees.ItemsSource = ConnectionClass.connect.Employes.OrderBy(z => z.FullName).ToList();
            }
            if (SortBox.SelectedIndex == 3)
            {
                ListEmployees.ItemsSource = ConnectionClass.connect.Employes.OrderByDescending(z => z.FullName).ToList();
            }
            if (SortBox.SelectedIndex == 4)
            {
                ListEmployees.ItemsSource = ConnectionClass.connect.Employes.OrderBy(z => z.Position).ToList();
            }
            if (SortBox.SelectedIndex == 5)
            {
                ListEmployees.ItemsSource = ConnectionClass.connect.Employes.OrderByDescending(z => z.Position).ToList();
            }
            if (SortBox.SelectedIndex == 6)
            {
                ListEmployees.ItemsSource = ConnectionClass.connect.Employes.OrderBy(z => z.Payment).ToList();
            }
            if (SortBox.SelectedIndex == 7)
            {
                ListEmployees.ItemsSource = ConnectionClass.connect.Employes.OrderByDescending(z => z.Payment).ToList();
            }
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
                        tr = ConnectionClass.connect.Teachers.Where(z => z.EmpID == selectedEm.ID).FirstOrDefault();
                        ConnectionClass.connect.Teachers.Remove(tr);
                        ConnectionClass.connect.Employes.Remove(selectedEm);
                        ConnectionClass.connect.SaveChanges();
                        update();
                    }
                    else
                        MessageBox.Show("Вы можете удалять сотрудников только своей кафедры!");
                }
            }
            else
                MessageBox.Show("Кто ты, воин?");
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FilterBox.SelectedValue.ToString() == "Имя")
                ListEmployees.ItemsSource = ConnectionClass.connect.Employes.Where(z => z.FullName.ToLower().Contains(TxtSearch.Text)).ToList();
            else if (FilterBox.SelectedValue.ToString() == "Позиция")
                ListEmployees.ItemsSource = ConnectionClass.connect.Employes.Where(z => z.Position.ToLower().Contains(TxtSearch.Text)).ToList();
            else if (FilterBox.SelectedValue.ToString() == "ID")
                ListEmployees.ItemsSource = ConnectionClass.connect.Employes.Where(z => z.ID.ToString().ToLower().Contains(TxtSearch.Text)).ToList();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            update();
        }
    }
}
