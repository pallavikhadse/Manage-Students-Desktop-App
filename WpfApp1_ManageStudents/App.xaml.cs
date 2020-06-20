using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1_ManageStudents
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ObservableCollection<Student> _students;   //static
        Random rnd = new Random(Guid.NewGuid().GetHashCode());
        public static List<string> _genders = new List<string> { "m", "f", "d" };    //static

        public App() { }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            MyStorage.WriteXml<ObservableCollection<Student>>(_students, "student.xml");
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // data => storage
            _students = MyStorage.ReadXml<ObservableCollection<Student>>("student.xml");

            if (_students == null)
            {
                _students = new ObservableCollection<Student>();

                //_students = GenerateStudents(10);
            }
        }

        private ObservableCollection<Student> GenerateStudents(int cnt)
        {
            List<string> fNames = new List<string> { "Pallavi", "Sheetal", "Roshini", "Swapnil", "Roshan", "Preet" };
            List<string> lNames = new List<string> { "Khadse", "Konar", "Sharma", "Malvarkar", "Soni", "Rawal" };

            var lst = new ObservableCollection<Student>();

            for (int i = 0; i < cnt; i++)
            {
                int fNo = rnd.Next(fNames.Count);
                int lNo = rnd.Next(lNames.Count);
                var gendr = fNo > 2 ? "m" : "f";
                lst.Add(new Student { firstName = "fname" + i, lastName = "lname" + i, matNumber = Math.Abs(Guid.NewGuid().GetHashCode()).ToString() });
                
            }
            return lst;
        }

    }
}
