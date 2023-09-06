using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Article
    {
        public Person author { get; set; }
        public string titleArticle { get; set; }
        public double raiting { get; set; }

        public Article(Person authorValue, string titleArticleValue, double raitingValue)
        {
            author = authorValue;
            titleArticle = titleArticleValue;
            raiting = raitingValue;
        }
        public Article() : this(new Person("Иван", "Иванов", new DateTime(2023, 01, 03, 18, 30, 25)), "Анализ принципов работы C#", 4)
        { }
        public override string ToString()
        {
            return author.ToString() + " " + titleArticle.ToString() + " " + raiting.ToString();
        }
    }
}
