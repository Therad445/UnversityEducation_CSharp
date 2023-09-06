using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CS_1
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Exercise 1

            Console.WriteLine("\n\n/* Exercise 1 */\n\n");
            Edition e1 = new Edition("Edition1", new DateTime(2020, 1, 1), 100_000);
            Edition e2 = new Edition("Edition1", new DateTime(2020, 1, 1), 100_000);
            Console.WriteLine(ReferenceEquals(e1, e2));
            Console.WriteLine($"e1 HashCode: {e1.GetHashCode()}\ne2 HashCode: {e2.GetHashCode()}\n" +
                              $"e1 == e2: {e1 == e2}\n");

            #endregion

            #region Exercise 2

            Console.WriteLine("\n\n/* Exercise 2 */\n\n");
            try
            {
                e1.Circulation = -100;
            }
            catch (NegativeCirculationException e)
            {
                Console.WriteLine(e.Message);   
            }
            
            #endregion

            #region Exercise 3

            Console.WriteLine("\n\n/* Exercise 3 */\n\n");
            Magazine m = new Magazine();
            
            Person p1 = new Person("Person1", "Surname1", new DateTime(1970, 1, 1));
            Person p2 = new Person("Person2", "Surname2", new DateTime(2003, 2, 2));
            Person p3 = new Person("Person3", "Surname3", new DateTime(2005, 3, 3));
            
            Article a1 = new Article(p1, "Article1", 5);
            Article a2 = new Article(p2, "SomeARTICLE", 4);
            Article a3 = new Article(p3, "Article3", 3);
            
            m.AddArticles(a1, a2);
            m.AddArticles(a3);
            
            m.AddEditors(p1);
            m.AddEditors(p2);

            Console.WriteLine(m.ToString());

            #endregion

            #region Exercise 4

            Console.WriteLine("\n\n/* Exercise 4 */\n\n");
            Console.WriteLine(m.GetEdition.ToString());

            #endregion

            #region Exercise 5

            Console.WriteLine("\n\n/* Exercise 5 */\n\n");
            Magazine mCopy = (Magazine)m.DeepCopy();
            m.Name = "New name";
            m.Circulation = 999;
            m.ReleaseDate = new DateTime(1900, 10, 10);
            Console.WriteLine($"Source object:\n{m.ToString()}\n\n*********************\n\n");
            Console.WriteLine($"Deep copy:\n{mCopy.ToString()}");
            
            #endregion

            #region Exercise 6
            
            Console.WriteLine("\n\n/* Exercise 6 */\n\n");
            double minRate = 3.5;
            Console.WriteLine($"Articles with rate more than {minRate}:\n");
            foreach (var art in m.FindArticlesWithHigherRating(minRate))
            {
                Console.WriteLine(art.ToString());
            }

            #endregion

            #region Exercise 7

            Console.WriteLine("\n\n/* Exercise 7 */\n\n");
            const string pattern = "Article";
            Console.WriteLine($"Articles with pattern \"{pattern}\" in name:");
            foreach (var art in m.FindArticlesWithSubstring(pattern))
            {
                Console.WriteLine(art.ToString());
            }

            #endregion

            #region Exercise 8

            Console.WriteLine("\n\n* Exercise 8 */\n\n");
            foreach (var art in m)
            {
                Console.WriteLine(art);
            }

            #endregion

            #region Exercise 9
            
            Console.WriteLine("\n\n/* Exercise 9 */\n\n");
            foreach (var article in m.FindArticlesWithEditorsAsAuthors())
            {
                Console.WriteLine(article.ToString());
            }

            #endregion

            #region Exercise 10

            Person ed = new Person();
            m.AddEditors(ed);
            
            // Article ar = new Article(ed, "New_ArticlE", 2.5);
            // m.AddArticles(ar);
            
            Console.WriteLine("\n\n/* Exercise 10 */\n\n");
            foreach (var editor in m.FindEditorsWithoutArticles())
            {
                Console.WriteLine(editor);
            }

            #endregion
        }
    }
}