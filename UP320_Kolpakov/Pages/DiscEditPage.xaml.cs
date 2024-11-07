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
    /// Логика взаимодействия для DiscEditPage.xaml
    /// </summary>
    public partial class DiscEditPage : Page
    {
        Disciple ds;
        string _role;
        int _caphId;
        public DiscEditPage(Disciple _d, string role, int caphId)
        {
            InitializeComponent();
            ds = _d;
            _role = role;
            _caphId = caphId;
            IdTxt.Text = ds.ID.ToString();
            CaphId.Text = ds.CaphID.ToString();
            NameTxt.Text = ds.Name;
            ValueTxt.Text = ds.Value.ToString();
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
                if (CaphId.Text == "")
                {
                    MessageBox.Show("Введите ID кафедры!");
                    break;
                }
                if (ValueTxt.Text == "")
                {
                    MessageBox.Show("Введите кол-во часов!");
                    break;
                }
                ds.ID = Convert.ToInt32(IdTxt.Text);
                ds.CaphID = Convert.ToInt32(CaphId.Text);
                ds.Name = NameTxt.Text;
                ds.Value = Convert.ToInt32(ValueTxt.Text);
                ConnectionClass.connect.SaveChanges();
                MessageBox.Show("Дисциплина успешно сохранена!");
                NavigationService.Navigate(new DiscPage(_role, _caphId));
                break;
            }
        }

        private void IdTxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            e.Handled = !char.IsDigit(e.Text, 0);
        }

        private void CaphId_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void ValueTxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
    }
}
