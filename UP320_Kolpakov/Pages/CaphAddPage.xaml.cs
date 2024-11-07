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
    /// Логика взаимодействия для CaphAddPage.xaml
    /// </summary>
    public partial class CaphAddPage : Page
    {
        string _role;
        int _caphId;
        public CaphAddPage(string role, int caphId)
        {
            InitializeComponent();
            _role = role;
            _caphId = caphId;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (IdTxt.Text == "")
                {
                    MessageBox.Show("Введите ID!");
                    break;
                }
                if (NameTxt.Text == "")
                {
                    MessageBox.Show("Введите название!");
                    break;
                }
                if (FacId.Text == "")
                {
                    MessageBox.Show("Введите ID факультета!");
                    break;
                }
                if (ShifrTxt.Text == "")
                {
                    MessageBox.Show("Введите шифр!");
                    break;
                }
                Caphedra c = new Caphedra();
                c.ID = Convert.ToInt32(IdTxt.Text);
                c.FacID = Convert.ToInt32(FacId.Text);
                c.Name = NameTxt.Text;
                c.shifr = ShifrTxt.Text;
                ConnectionClass.connect.Caphedra.Add(c);
                ConnectionClass.connect.SaveChanges();
                MessageBox.Show("Кафедра успешно добавлена!");
                NavigationService.Navigate(new CaphPage(_role, _caphId));
                break;
            }
        }

        private void IdTxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }

        private void FacId_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }

        private void NameTxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void ShifrTxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
