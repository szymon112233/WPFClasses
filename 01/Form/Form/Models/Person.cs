using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form.Models
{
    public enum Sex
    {
        MALE = 0,
        FEMALE
    }

    class Person
    {
        private string name;
        private string surname;
        private DateTime bday;
        private Sex sex;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public DateTime Bday { get => bday; set => bday = value; }
        public Sex Sex { get => sex; set => sex = value; }

        public Person(string name, string surname, DateTime bday, Sex sex)
        {
            this.name = name;
            this.surname = surname;
            this.bday = bday;
            this.sex = sex;
        }

        public Person()
        {

        }


    }
}
