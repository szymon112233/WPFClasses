using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using DatabaseWPF.Models;

namespace DatabaseWPF
{
    class XMLHelper
    {
        public static void saveData(object obj, string filename)
        {
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(@".\"+filename);
            sr.Serialize(writer, obj);
            writer.Close();
        }

        public static Users getUsersData()
        {
            Users users = new Users();
            XmlSerializer reader = new XmlSerializer(typeof(Users));
            if (File.Exists(@".\users.xml"))
            {
                StreamReader file = new StreamReader(@".\users.xml");
                users = (Users)reader.Deserialize(file);
                file.Close();
            }
            return users;
        }
        public static Cars getCarsData()
        {
            Cars cars = new Cars();
            XmlSerializer reader = new XmlSerializer(typeof(Cars));
            if (File.Exists(@".\cars.xml"))
            {
                StreamReader file = new StreamReader(@".\cars.xml");
                cars = (Cars)reader.Deserialize(file);
                file.Close();
            }
            return cars;
        }

        public static Products getProductsData()
        {
            Products products = new Products();
            XmlSerializer reader = new XmlSerializer(typeof(Products));
            if (File.Exists(@".\products.xml"))
            {
                StreamReader file = new StreamReader(@".\products.xml");
                products = (Products)reader.Deserialize(file);
                file.Close();
            }
            return products;
        }

    }
}
