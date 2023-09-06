using System;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Article article1 = new Article(new Person("Радмир", "Исламов", new DateTime(2022, 12, 20, 18, 30, 25)), "Философия языка C#", 4.5);
            Article article2 = new Article(new Person("Виктор ", "Бут", new DateTime(2022, 10, 15, 18, 30, 25)), "Работа с Java", 4.1);
            Magazine magazine = new Magazine();
            magazine.AddArticles(article1, article2);
            Console.WriteLine(magazine.ToShortString());
            Console.WriteLine("--------------------------");
            Console.WriteLine(magazine[Frequency.Weekly]);
            Console.WriteLine(magazine[Frequency.Mountly]);
            Console.WriteLine(magazine[Frequency.Yearly]);
            Console.WriteLine("--------------------------");
            magazine = new Magazine("Times", Frequency.Mountly, new DateTime(2023, 01, 04, 18, 30, 25), 100000);
            magazine.AddArticles(article1, article2);
            Console.WriteLine(magazine.ToString());
            Console.WriteLine("--------------------------");
            Console.WriteLine("--------------------------");

            Console.WriteLine("Введите количество строк и столбцов:");
            string? input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Вы ввели пустую строку!");
                Environment.Exit(1);

            }
            string[] nums = input.Split(' ', ',', '-');
            int nrow = Convert.ToInt32(nums[0]), ncolumns = Convert.ToInt32(nums[1]), N = nrow * ncolumns;
            Stopwatch sw = new Stopwatch();
            Article[] arr1 = new Article[N];
            for (int i = 0; i < N; i++)
            {
                arr1[i] = new Article();
            }
            sw.Start();
            for (int i = 0; i < N; i++)
            {
                arr1[i].titleArticle = "Text";
            }
            sw.Stop();
            Console.WriteLine("Одномерный массив: {0}", sw.Elapsed.Ticks);


            Console.WriteLine("--------------------------");
            Console.WriteLine("--------------------------");
            Article[,] arr2 = new Article[nrow, ncolumns];
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumns; j++)
                {
                    arr2[i, j] = new Article();
                }
            }
            sw.Restart();
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumns; j++)
                {
                    arr2[i, j].titleArticle = "Text";
                }
            }
            sw.Stop();
            Console.WriteLine("Двухмерный прямоугольный массив: {0}", sw.Elapsed.Ticks);


            Console.WriteLine("--------------------------");
            Console.WriteLine("--------------------------");
            Article[][] arr3 = new Article[nrow][];
            for (int i = 0; i < nrow; i++)
            {
                arr3[i] = new Article[ncolumns];
                for (int j = 0; j < ncolumns; j++)
                {
                    arr3[i][j] = new Article();
                }
            }
            sw.Restart();
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumns; j++)
                {
                    arr3[i][j].titleArticle = "Text";
                }
            }
            sw.Stop();
            Console.WriteLine("Двухмерный ступенчатый массив: {0}", sw.Elapsed.Ticks);


        }
    }
}