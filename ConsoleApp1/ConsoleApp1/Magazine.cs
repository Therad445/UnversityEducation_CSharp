using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Magazine
    {

        private string titleMagazine;
        private Frequency period;
        private DateTime dateRelease;
        private int circulation;
        private Article[] articles;

        public Magazine(string titleMagazineValue, Frequency periodValue, DateTime dateReleaseValue, int circulationValue)
        {
            titleMagazine = titleMagazineValue;
            period = periodValue;
            dateRelease = dateReleaseValue;
            circulation = circulationValue;
        }

        public Magazine() : this("Новая газета", Frequency.Weekly, new DateTime(2023, 01, 03, 18, 30, 25), 20000)
        { }
        public string TitleMagazine
        {
            get { return titleMagazine; }
            set { titleMagazine = value; }
        }
        public Frequency Period
        {
            get { return period; }
            set { period = value; }
        }
        public DateTime DateRelease
        {
            get { return dateRelease; }
            set { dateRelease = value; }
        }
        public int Circulation
        {
            get { return circulation; }
            set { circulation = value; }
        }
        public Article[] Articles
        {
            get { return articles; }
            set { articles = value; }
        }
        public double MediumRaiting
        {
            get
            {
                double rate = 0;
                if (articles == null) return 0;
                foreach (var elemArticle in articles)
                {
                    rate += elemArticle.raiting;
                }
                return rate / articles.Length;
            }

        }
        public bool this[Frequency index]
        {
            get
            {
                return period == index;
            }
        }
        public void AddArticles(params Article[] newArticles)
        {
            if (articles == null)
            {
                articles = newArticles;
            }
            else
            {
                Array.ConstrainedCopy(newArticles, 0, articles, articles.Length, newArticles.Length);
            }
        }
        public override string ToString()
        {
            string ArticlesList = "";
            foreach (var elem in articles)
            {
                ArticlesList += elem + " ";
            }
            return titleMagazine + " " + period + " " + circulation + " " + ArticlesList;
        }
        public string ToShortString()
        {
            return titleMagazine + " " + period + " " + circulation + " " + MediumRaiting;
        }
    }
}
