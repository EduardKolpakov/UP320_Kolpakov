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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        string _role;
        int _caphId;
        public AddPage(string role, int caphId)
        {
            InitializeComponent();
            _role = role;
            _caphId = caphId;
            PosBox.Items.Add("зав. кафедрой");
            PosBox.Items.Add("преподаватель");
            PosBox.Items.Add("инженер");
            RangBox.Items.Add("профессор");
            RangBox.Items.Add("доцент");
            RangBox.Items.Add("ассистент");
            StepBox.Items.Add("к. ф.-м. н.");
            StepBox.Items.Add("д. т.н.");
            StepBox.Items.Add("д. ф.-м. н.");
            StepBox.Items.Add("к. т.н.");
            StepBox.Items.Add("-");
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
                if (FullNameTxt.Text == "")
                {
                    MessageBox.Show("Введите ФИО!");
                    break;
                }
                if (CaphIdTxt.Text == "")
                {
                    MessageBox.Show("Введите ID кафедры!");
                    break;
                }
                if (ChiefId.Text == "")
                {
                    MessageBox.Show("Введите ID шефа!");
                    break;
                }
                if (PosBox.SelectedItem == null)
                {
                    MessageBox.Show("Выберите позицию!");
                    break;
                }
                Employe em = new Employe();
                em.ID = Convert.ToInt32(IdTxt.Text);
                em.FullName = FullNameTxt.Text;
                if (_role == "зав" && _caphId != Convert.ToInt32(_caphId))
                {
                    MessageBox.Show("Вы можете добавлять сотрудников только в свою кафедру!");
                    CaphIdTxt.Text = _caphId.ToString();
                }
                em.CaphID = Convert.ToInt32(CaphIdTxt.Text);
                em.Chief = Convert.ToInt32(ChiefId.Text);
                em.Position = PosBox.SelectedValue.ToString();
                ConnectionClass.connect.Employes.Add(em);
                if (em.Position != "инженер")
                {
                    Teacher t = new Teacher();
                    t.ID = em.ID;
                    t.EmpID = em.ID;
                    t.rang = RangBox.SelectedValue.ToString();
                    t.stepen = StepBox.SelectedValue.ToString();
                    ConnectionClass.connect.Teachers.Add(t);
                }
                ConnectionClass.connect.SaveChanges();
                MessageBox.Show("Сотрудник добавлен!");
                NavigationService.Navigate(new MainPage(_role, _caphId));
                break;
            }
        }

        private void RangBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RangBox.SelectedValue.ToString() == "ассистент")
            {
                StepBox.SelectedIndex = StepBox.Items.Count - 1;
            }
        }

        private void PosBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PosBox.SelectedValue.ToString() == "инженер")
            {
                RangBox.Visibility = Visibility.Hidden;
                StepBox.Visibility = Visibility.Hidden;
                RLBL.Visibility = Visibility.Hidden;
                SLBL.Visibility = Visibility.Hidden;
            }
            else
            {
                RangBox.Visibility = Visibility.Visible;
                StepBox.Visibility = Visibility.Visible;
                RLBL.Visibility = Visibility.Visible;
                SLBL.Visibility = Visibility.Visible;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
