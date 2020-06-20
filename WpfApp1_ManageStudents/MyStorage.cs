using System;
using System.IO;
using System.Linq.Expressions;
using System.Windows;
using System.Xml.Serialization;

namespace WpfApp1_ManageStudents
{
    internal class MyStorage
    {
        internal static void WriteXml<T>(T data, string filename)
        {
            try
            {
                XmlSerializer sr = new XmlSerializer(typeof(T));
                FileStream stream = new FileStream(filename, FileMode.Create);

                sr.Serialize(stream, data);
                stream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error");
                throw;
            }
            
        }

        internal static T ReadXml<T>(string file)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));

                    return (T)serializer.Deserialize(sr);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error");
                return default(T);
            }
        }
    }
}