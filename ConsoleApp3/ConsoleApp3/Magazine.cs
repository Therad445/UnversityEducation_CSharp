using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace CS_3
{
    public class Magazine : Edition, IRateAndCopy
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

        public Magazine() : this("Magazine", Frequency.Monthly, new DateTime(2020, 1, 1), 100_000) {}
        

        #endregion

        #region Properties

        public double Rating { get; }

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
            get => new Edition(name, releaseDate, circulation);

            set
            {
                name = value.Name;
                releaseDate = value.ReleaseDate;
                circulation = value.Circulation;
            }
        }

        public Frequency OutputFrequency => outputFrequency;

        #endregion

        #region Methods
        
        public void AddArticles(params Article[] _articles)
        {
            if (articles == null) articles = new List<Article>();
            articles.AddRange(_articles);
        }

        public override string ToString()
        {
            string str = $"Name: {name}\n" +
                         $"Frequency: {outputFrequency}\n" +
                         $"Release date: {releaseDate.ToShortDateString()}\n" +
                         $"Circulation: {circulation}\n";
            // could articles and editors be null???
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
            if (editors == null) editors = new List<Person>();
            editors.AddRange(_editors);
        }

        public override object DeepCopy()
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
        }

        public void SortArticlesByArticleName()
        {
            articles.Sort(); // use default comparator == 'CompareTo' method of array elements' type
        }

        public void SortArticlesByAuthorSurname()
        {
            articles.Sort(new Article());
        }

        public void SortArticlesByArticleRate()
        {
            articles.Sort(new ArticleComparerByRate());
        }а

        public void PrintArticles()
        {
            foreach (var article in articles)
            {
                Console.WriteLine(article.ToString());
            }
        }

        #endregion

        #region Iterators

        public IEnumerable FindArticlesWithHigherRating(double rate)
        {
            foreach (object? article in articles)
            {
                var a = article as Article;
                if (a.Rate > rate) yield return a;
            }
        }

        public IEnumerable FindArticlesWithSubstring(string substr)
        {
            foreach (var article in articles)
            {
                var a = article as Article;
                if (a.ArticleName.Contains(substr)) yield return a;
            }
        }

        public IEnumerable FindArticlesWithEditorsAsAuthors()
        {
            foreach (var article in articles)
            {
                var a = article as Article;
                if (editors.Contains(a.Author)) yield return a;
            }
        }

        public IEnumerable FindEditorsWithoutArticles()
        {
            foreach (var editor in editors)
            {
                var e = editor as Person;
                bool haveArticles = false;
                foreach (var article in articles)
                {
                    var a = article as Article;
                    if (e.Equals(a.Author)) haveArticles = true;
                }

                if (haveArticles == false) yield return e;

            }
        }
        
        public IEnumerator GetEnumerator()
        {
            return new MagazineEnumerator(editors, articles);
        }

        #endregion
    }
    
    class MagazineEnumerator : IEnumerator
    {
        private int position;
        private List<Person> editors;
        private List<Article> articles;

        public MagazineEnumerator(List<Person> _editors, List<Article> _articles)
        {
            position = -1;
            editors = _editors;
            articles = _articles;
        }
        
        public bool MoveNext()
        {
            if (position < articles.Count - 1)
            {
                position++;
                var art = articles[position] as Article;
                while (editors.Contains(art.Author))
                {
                    position++;
                    if (position >= articles.Count) return false;
                    art = articles[position] as Article;
                }
                return true;
            }
            else return false;
        }

        public object? Current
        {
            get
            {
                if (position == -1 || position >= articles.Count) throw new InvalidOperationException();
                return articles[position];
            }
        }

        public void Reset()
        {
            position = -1;
        }
    }
}