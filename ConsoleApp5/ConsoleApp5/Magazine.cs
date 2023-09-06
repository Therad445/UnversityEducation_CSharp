using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CS_5
{
    [Serializable]
    public class Magazine : Edition
    {
        
        #region Fields
        
        private Frequency outputFrequency;
        private List<Person> editors = new List<Person>();
        private List<Article> articles = new List<Article>();
        
        #endregion

        #region Constructors
        
        public Magazine(string _name, Frequency _outputFrequency, DateTime _releaseDate, int _circulation)
        {
            name = _name;
            outputFrequency = _outputFrequency;
            releaseDate = _releaseDate;
            circulation = _circulation;
        }

        public Magazine() : this(
            "Magazine",
            Frequency.Monthly,
            new DateTime(2020, 1, 1),
            100_000)
        {
            
        }
        

        #endregion

        #region Properties

        public double Rating { get; set; }

        public double GetAverageRate
        {
            get
            {
                if (articles == null) return 0;
                double sum = 0;
                foreach (var o in articles)
                {
                    Article a = o as Article;
                    sum += a.Rate;
                }
                return sum / articles.Count;
            }
        }

        public List<Article> Articles => articles;

        public ArrayList Editors { get; }
        
        public Edition GetEdition {
            set
            {
                name = value.Name;
                releaseDate = value.ReleaseDate;
                circulation = value.Circulation;
            }
        }

        public Frequency OutputFrequency { get; set; }

        #endregion

        #region Methods
        
        public void AddArticles(params Article[] _articles)
        {
            articles.AddRange(_articles);
        }

        public override string ToString()
        {
            string str = $"Name: {name}\n" +
                         $"Frequency: {outputFrequency}\n" +
                         $"Release date: {releaseDate.ToShortDateString()}\n" +
                         $"Circulation: {circulation}\n";
            str += "Artciles:\n";
            int i = 0;
            foreach (var article in articles)
            {
                i++;
                Article a = article as Article;
                str += a.ToString();
                str += i == articles.Count ? "" : "----------------------------------\n";
            }

            str += "\n**********************************\n\n";
            
            str += "Editors:\n";
            i = 0;
            foreach (var editor in editors)
            {
                i++;
                Person p = editor as Person;
                str += p.ToString();
                str += i == editors.Count ? "" : "----------------------------------\n";
            } 
            
            return str;
        }

        public virtual string ToShortstring()
        {
            string str =
                $"Name: {name}\n" +
                $"Frequency: {outputFrequency}\n" +
                $"Release date: {releaseDate.ToShortDateString()}\n" +
                $"Circulation: {circulation}\n" +
                $"Rate: {Convert.ToString(GetAverageRate)}\n" +
                $"Editors: {editors.Count}\n" +
                $"Articles: {articles.Count}\n";
            return str;
        }

        public void AddEditors(params Person[] _editors)
        {
            editors.AddRange(_editors);
        }

        /*public override object DeepCopy()
        {
            Magazine m = new Magazine();

            m.outputFrequency = outputFrequency;
            m.circulation = circulation;
            m.name = name;
            m.releaseDate = releaseDate;
            
            m.articles = new List<Article>();
            foreach (Article art in articles)
            {
                m.articles.Add((Article)art.DeepCopy());
            }
            
            m.editors = new List<Person>();
            foreach (Person person in editors)
            {
                m.editors.Add((Person)person.DeepCopy());
            }

            return m;
        }*/

        public void PrintArticles()
        {
            foreach (var article in articles)
            {
                Console.WriteLine(article.ToString());
            }
        }

        public new Magazine DeepCopy()
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin);
                return (Magazine) formatter.Deserialize(stream);
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something goes wrong");
                Console.ResetColor();
                return new Magazine();
            }
            
        }

        public bool Save(string filename)
        {
            try
            {
                var formatter = new BinaryFormatter();
                using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, this);
                }

                return true;
            }
            catch
            {
                return false;
            }
           
        }

        public bool Load(string filename)
        {
            try
            {
                var formatter = new BinaryFormatter();
                using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    var m = (Magazine) formatter.Deserialize(fs);
                    name = m.name;
                    releaseDate = m.releaseDate;
                    circulation = m.circulation;
                    outputFrequency = m.outputFrequency;
                    articles.Clear();
                    articles.AddRange(m.articles);
                    editors.Clear();
                    editors.AddRange(m.editors);

                    return true;
                }
            }
            catch
            {
                return false;
            }

        }

        public bool AddFromConsole()
        {
            try
            {
                Console.WriteLine(
                    "Enter article info in format:\n" +
                    "authorName-authorSurname-birthdayYear-birthdayMonth-birthdayDay-articleName-rate"
                );
                string[] words = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);
                var tempAuthor = new Person(words[0], words[1],
                    new DateTime(
                        Convert.ToInt32(words[2]),
                        Convert.ToInt32(words[3]),
                        Convert.ToInt32(words[4])));
                articles.Add(
                    new Article(tempAuthor, words[5], Convert.ToDouble(words[6])));
                return true;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
                Console.ResetColor();
                return false;
            }
            
        }

        public static bool Save(string filename, Magazine obj)
        {
            try
            {
                var formatter = new BinaryFormatter();
                using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, obj);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error in static Save");
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return false;
            }
        }

        public static bool Load(string filename, Magazine obj)
        {
            try
            {
                var formatter = new BinaryFormatter();
                using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    var m = (Magazine) formatter.Deserialize(fs);
                    obj.name = m.name;
                    obj.releaseDate = m.releaseDate;
                    obj.circulation = m.circulation;
                    obj.outputFrequency = m.outputFrequency;
                    
                    obj.articles.Clear();
                    obj.articles.AddRange(m.articles);
                    
                    obj.editors.Clear();
                    obj.editors.AddRange(m.editors);

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Operators

        public static bool operator ==(Magazine lhs, Magazine rhs)
        {
            return lhs.outputFrequency == rhs.outputFrequency 
                   && lhs.editors.SequenceEqual(rhs.editors)
                   && lhs.articles.SequenceEqual(rhs.articles);
        }

        public static bool operator !=(Magazine lhs, Magazine rhs)
        {
            return lhs.outputFrequency != rhs.outputFrequency
                   || !lhs.editors.SequenceEqual(rhs.editors)
                   || !lhs.articles.SequenceEqual(rhs.articles);
        }

        #endregion
    }
    
}