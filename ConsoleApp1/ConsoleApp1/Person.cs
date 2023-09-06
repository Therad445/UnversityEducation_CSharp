using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Person
    {
        private string name;
        private string surname;
        private DateTime birthday;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameValue"></param>
        /// <param name="surnameValue"></param>
        /// <param name="birthdayValue"></param>
        public Person(string nameValue, string surnameValue, DateTime birthdayValue)
        {
            name = nameValue;
            surname = surnameValue;
            birthday = birthdayValue;
        }
        public Person() : this("Иван", "Иванов", new DateTime(2023, 01, 03, 18, 30, 25))
        { }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        public int ChangeYear
        {
            get
            {
                return birthday.Year;
            }
            set
            {
                birthday = new DateTime(value, birthday.Month, birthday.Day);
            }
        }
        public override string ToString()
        {
            return name + " " + surname + " " + birthday.ToString();
        }
        public string ToShortString()
        {
            return name + "" + surname;
        }
    }
}
