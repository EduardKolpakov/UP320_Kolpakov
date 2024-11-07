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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
            var z = ConnectionClass.connect.Employes.ToList();
            foreach (var items in z)
            {
                EmployeeChoice.Items.Add(items.ID);
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                string login = LoginTxt.Text;
                string password = PassTxt.Password;
                int emID = Convert.ToInt32(EmployeeChoice.SelectedValue);
                if (login == "")
                {
                    MessageBox.Show("Введите логин!");
                    break;
                }
                if (password == "")
                {
                    MessageBox.Show("Введите пароль!");
                    break;
                }
                Login newlog = new Login();
                newlog.Login1 = login;
                newlog.Password = password;
                if (emID != 0)
                {
                    newlog.EmpID = emID;
                }
                ConnectionClass.connect.Logins.Add(newlog);
                ConnectionClass.connect.SaveChanges();
                NavigationService.GoBack();
            }
        }
    }
}
