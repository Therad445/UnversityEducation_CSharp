using System;
using System.Collections.Generic;

namespace CS_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var mg = new Magazine("magazine1", Frequency.Monthly, new DateTime(2020, 1, 1), 100_000);

            var a1 = new Article(new Person("aaa", "bbb", new DateTime(2020, 1, 1)), "name1", 3);
            var a2 = new Article(new Person("aaa", "aaa", new DateTime(2020, 1, 1)), "name3", 2);
            var a3 = new Article(new Person("a", "a", new DateTime(2020, 1, 1)), "name2", 5);
            mg.AddArticles(a1, a2, a3);

            #region Sorts

            Console.WriteLine("Before sorting:");
            mg.PrintArticles();
            Console.WriteLine("----------------------------------------------------");


            Console.WriteLine("Sorted by article name:");
            mg.SortArticlesByArticleName();
            mg.PrintArticles();
            Console.WriteLine("----------------------------------------------------");


            Console.WriteLine("Sorted by article rate");
            mg.SortArticlesByArticleRate();
            mg.PrintArticles();
            Console.WriteLine("----------------------------------------------------");

            Console.WriteLine("Sorted by author surname");
            mg.SortArticlesByAuthorSurname();
            mg.PrintArticles();
            Console.WriteLine("----------------------------------------------------");

            #endregion

            #region Part 2

            Console.WriteLine("\n\nPart 2\n\n");
            KeySelector<String> selector = delegate(Magazine magazine) { return magazine.GetHashCode().ToString(); };
            MagazineCollection<String> mgCollection = new MagazineCollection<string>(selector);
            mgCollection.AddDefaults();
            mgCollection.AddMagazines(mg);
            Console.WriteLine(mg);

            #endregion

            #region Part 3

            Console.WriteLine(mgCollection.MaxAverageRate);


            var mgGroups = mgCollection.FrequencyGroup(Frequency.Monthly);
            Console.WriteLine("Magazine with monthly output frequency: ");
            foreach (var keyValuePair in mgGroups)
            {
                Console.WriteLine(keyValuePair.Value);
            }


            foreach (var item in mgCollection.GroupCollection)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine();
                foreach (var name in item)
                {
                    Console.WriteLine(name);
                }
            }

            #endregion


            int num = -1;
            Console.Write("Enter length of collection: ");
            while (!int.TryParse(Console.ReadLine(), out num) || num < 0)
            {
                Console.Write("Invalid input. Try again: ");
            }
            
            GenerateElement<Edition, Magazine> d = delegate(int j)
            {
                var key = new Edition("Edition", new DateTime(2000 + j % 30, 1+ j % 12, 1 + j % 30), j + 100_000);
                var value = new Magazine("Magazine", (Frequency)(j % 3), new DateTime(2000 + j % 30, 1+ j % 12, 1 + j % 30), j + 100_000);
                return new KeyValuePair<Edition, Magazine>(key, value);
            };
            
            var searchTest = new TestCollections<Edition, Magazine>(num, d);
            searchTest.searchKeyList();
            searchTest.searchStrList();
            searchTest.searchTKeyDictionaryByKey();
            searchTest.searchStrDictionaryByKey();
            searchTest.searchTKeyDictionaryByValue();
        }
    }
}