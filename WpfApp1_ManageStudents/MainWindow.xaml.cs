using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfApp1_ManageStudents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        Random rnd = new Random();
        //Student canditate;
        //int studentsCnt;


        public MainWindow()
        {
            InitializeComponent();

            //studentsCnt = App._students.Count;

        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("We managed to do it!");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var sortListbox = App._students.OrderBy(s => s.firstName);
            Lbx_Students.ItemsSource = sortListbox;

            // Lbx_Students.ItemsSource = App._students;

            CoBx_gender.ItemsSource = App._genders;                     

            //CoBx_picked.ItemsSource = new List<bool> { true, false };
        }        

        private void Tbx_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = (sender as TextBox).Text.ToLower();
            var lst = from s in App._students where s.name.ToLower().Contains(filter) select s;
            Lbx_Students.ItemsSource = lst;
        }

        //private void Btn_PickOne_Click(object sender, RoutedEventArgs e)
        //{
        //    Lbx_Students.SelectedItem = null;
        //    var cnt = App._students.Count(x => x.picked);
        //    do
        //    {
        //        canditate = App._students[ rnd.Next(studentsCnt)];
        //    } while (cnt < studentsCnt && canditate.picked);

        //    //if (!canditate.picked)

        //}

        private void Btn_Add_Click (object sender, RoutedEventArgs e)
        {
            Student stud = new Student { firstName = "please edit", lastName = "please edit", matNumber = Math.Abs(Guid.NewGuid().GetHashCode()).ToString() };
            App._students.Add(stud);
            Lbx_Students.SelectedItem = stud;
            Lbx_Students.ScrollIntoView(stud);
        }

        private void Btn_Del_Click (object sender, RoutedEventArgs e)
        {
            var itm = Lbx_Students.SelectedItem;
            if (itm ==null)
            {
                MessageBox.Show("Please select an item to be deleted first !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var toDelete = itm as Student;
            var res = MessageBox.Show($" Are you sure you want to delete {toDelete.firstName} {toDelete.lastName} ?", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (res == MessageBoxResult.OK)
                App._students.Remove(toDelete);
        }

        private void Btn_GoToWindow_Click(object sender, RoutedEventArgs e)
        {
            var win = new W_Test();
            win.Owner = this;
            Visibility = Visibility.Hidden;
            win.ShowDialog();
        }

        private void Btn_Gender_Click(object sender, RoutedEventArgs e)
        {
            var lst = from s in App._students where s.gender == "f" select s;
            Lbx_Students.ItemsSource = lst;
        }
    }
}
