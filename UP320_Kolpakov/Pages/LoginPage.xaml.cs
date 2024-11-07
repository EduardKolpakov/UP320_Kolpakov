using Microsoft.Win32.SafeHandles;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            int caphId = 0;
            string role = "";
            string log = LoginTxt.Text;
            string pas = PassTxt.Password;
            var z = ConnectionClass.connect.Logins.Where(a => a.Login == log && a.Password == pas).FirstOrDefault();
            if (z != null)
            {
                var zc = ConnectionClass.connect.Employe.Where(a => a.ID == z.EmpID).FirstOrDefault();
                if (zc != null)
                {
                    caphId = Convert.ToInt32(zc.CaphID);

                    if (zc.Position == "зав. кафедрой")
                    {
                        role = "зав";
                    }
                    else if (zc.Position == "инженер")
                    {
                        role = "инженер";
                    }
                }
                else
                {
                    role = "студент";
                }
                MessageBox.Show("Добро пожаловать!");
                NavigationService.Navigate(new MainPage(role, caphId));
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }
    }
}
