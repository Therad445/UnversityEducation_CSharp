using System;

namespace CS_1
{
    public class Edition
    {
        #region Fields

        protected string name;
        protected DateTime releaseDate;
        protected int circulation;


        #endregion

        #region Constructors

        public Edition(string _name, DateTime _releaseDate, int _circulation)
        {
            name = _name;
            releaseDate = _releaseDate;
            circulation = _circulation;
        }

        public Edition() : this("Default", new DateTime(2020, 1, 1), 100_000) {}

        #endregion

        #region Properties

        public string Name
        {
            get => name;
            set => name = value;
        }

        public DateTime ReleaseDate
        {
            get => releaseDate;
            set => releaseDate = value;
        }

        public int Circulation
        {
            get => circulation;
            set
            {
                if (value < 0)
                {
                    throw new NegativeCirculationException("Circulation cannot be negative\n");
                }
            }
        }

        #endregion

        #region Methods

        public virtual object DeepCopy()
        {
            return new Edition {circulation = this.circulation, name = this.name, releaseDate = this.releaseDate};
        }

        public override bool Equals(object? obj)
        {
            Edition ed = obj as Edition;
            if (ed.name == name && ed.circulation == circulation && ed.releaseDate == releaseDate) return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() + circulation.GetHashCode() + releaseDate.GetHashCode();
        }

        public override string ToString()
        {
            return $"Name: {name}\nReleased from: {releaseDate.ToShortDateString()}\nCirculation: {circulation}";
        }

        #endregion

        #region Operators

        public static bool operator ==(Edition e1, Edition e2)
        {
            if (e1.Equals(e2)) return true;
            else return false;
        }

        public static bool operator !=(Edition e1, Edition e2)
        {
            return !(e1 == e2);
        }

        #endregion
    }
}