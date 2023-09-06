using System;
using System.Security.Cryptography;

namespace CS_5
{
    [Serializable]
    public class Person
    {
        #region Fields
        private string name;
        private string surname;
        private DateTime birthday;
        #endregion

        #region Constructors
        public Person(string _name, string _surname, DateTime _birthday)
        {
            name = _name;
            surname = _surname;
            birthday = _birthday;
        }

        public Person() : this("Kirill", "Dolbilov", new DateTime(2020, 1, 1)) {}
        #endregion
        
        #region Properties
        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Surname
        {
            get => surname;
            set => surname = value;
        }

        public DateTime Birthday
        {
            get => birthday;
            set => birthday = value;
        }

        public int ChangeBirthdayYear
        {
            get => birthday.Year;
            set => birthday = new DateTime(value, birthday.Month, birthday.Day);
        }
        #endregion
        
        #region Methods
        public override string ToString()
        {
            return $"\t\tSurname: {surname}\n" +
                   $"\t\tName: {name}\n" +
                   $"\t\tBirthday: {birthday.ToShortDateString()}\n";
        }

        public virtual string ToShortString()
        {
            return name + " " + surname;
        }

        public override bool Equals(object? obj)
        {
            Person p = obj as Person;
            if (p.surname == surname && p.name == name && p.birthday == birthday) return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return surname.GetHashCode() + name.GetHashCode() + birthday.GetHashCode();
        }

        public object DeepCopy()
        {
            return new Person {birthday = this.birthday, surname = this.surname, name = this.name};
        }

        #endregion
        
        #region Operators
        public static bool operator ==(Person p1, Person p2) => p1.Equals(p2);

        public static bool operator !=(Person p1, Person p2) => !p1.Equals(p2);
        #endregion
    }
}