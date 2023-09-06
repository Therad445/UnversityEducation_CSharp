using System;
using System.Collections.Generic;

namespace CS_3
{
    public class Article : IRateAndCopy, IComparable, IComparer<Article> {
        #region Properties

        public Person Author { get; set; }
        public string ArticleName { get; set; }
        public double Rate { get; set; }

        public double Rating { get; }

        #endregion
        
        #region Constructors
        public Article(Person _author, string _articleName, double _rate)
        {
            Author = _author;
            ArticleName = _articleName;
            Rate = _rate;
        }

        public Article() : this(new Person("Alex", "John", new DateTime(2020, 1, 1)), 
            "How to study?", 
            5.0) {}
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"\tAuthor:\n{Author.ToString()}" +
                   $"\tArticle name: {ArticleName}\n" +
                   $"\tRating: {Rate}\n";
        }

        public object DeepCopy()
        {
            return new Article 
                {
                    Author = this.Author, 
                    Rate = this.Rate, 
                    ArticleName = this.ArticleName
                };
        }

        // compare by article name
        public int CompareTo(object obj)
        {
            var art = obj as Article;
            if (art.ArticleName != null) return ArticleName.CompareTo(art.ArticleName);
            throw new Exception("Article name is NULL");
        }

        // compare by author surname
        public int Compare(Article x, Article y)
        {
            return x.Author.Surname.CompareTo(y.Author.Surname);
        }

        #endregion
        
    }

    // Compare by article rate
    class ArticleComparerByRate : IComparer<Article>
    {
        public int Compare(Article x, Article y)
        {
            if (x == null && y == null) return 0;
            else if (x == null) return -1;
            else if (y == null) return 1;
            
            if (x.Rate > y.Rate) return 1;
            if (y.Rate > x.Rate) return -1;
            return 0;
        }
    }
}