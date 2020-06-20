using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApp1_ManageStudents
{
    public class Student
    {
        public string matNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }   // m,f,d

        [XmlIgnoreAttribute]
        public string name { get { return $"{firstName} {lastName}"; } } 

        public bool picked { get; set; }
    }
}
