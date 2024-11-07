using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        Employe em;
        Teacher t;
        string _role;
        int _caphId;
        public EditPage(Employe _em, string role, int caphId)
        {
            _role = role;
            _caphId = caphId;
            InitializeComponent();
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
            em = _em;
            IdTxt.Text = em.ID.ToString();
            CaphIdTxt.Text = em.CaphID.ToString();
            PosBox.SelectedValue = em.Position.ToString();
            FullNameTxt.Text = em.FullName.ToString();
            ChiefId.Text = em.Chief.ToString();
            if (em.Position != "инженер")
            {
                t = ConnectionClass.connect.Teachers.Where(z => z.EmpID == em.ID).FirstOrDefault();
                RangBox.SelectedValue = t.rang.ToString();
                StepBox.SelectedValue = t.stepen.ToString();
            }
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
                em.ID = Convert.ToInt32(IdTxt.Text);
                em.CaphID = Convert.ToInt32(CaphIdTxt.Text);
                em.Position = PosBox.SelectedValue.ToString();
                em.FullName = FullNameTxt.Text;
                em.Chief = Convert.ToInt32(ChiefId.Text);
                if (em.Position == "инженер" && PosBox.SelectedValue.ToString() != "инженер")
                {
                    Teacher teacher = new Teacher();
                    teacher.ID = em.ID;
                    teacher.EmpID = em.ID;
                    teacher.rang = RangBox.SelectedValue.ToString();
                    teacher.stepen = StepBox.SelectedValue.ToString();
                    ConnectionClass.connect.Teachers.Add(teacher);
                }
                else if (em.Position != "инженер" && PosBox.SelectedValue.ToString() == "инженер")
                {
                    ConnectionClass.connect.Teachers.Remove(t);
                }
                else
                {
                    t.rang = RangBox.SelectedValue.ToString();
                    t.stepen = StepBox.SelectedValue.ToString();
                }
                ConnectionClass.connect.SaveChanges();
                MessageBox.Show("Данные изменены!");
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
