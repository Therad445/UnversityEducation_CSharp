using System;

namespace CS_1
{
    class Article : IRateAndCopy {
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
            return new Article {Author = this.Author, Rate = this.Rate, ArticleName = this.ArticleName};
        }
        #endregion
        
    }
}