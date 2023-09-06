using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CS_3
{
    public delegate KeyValuePair<TKey, TValue>
        GenerateElement<TKey, TValue>(int j);

    public class TestCollections<TKey, TValue>
    {
        private List<TKey> tKeyList = new List<TKey>();
        private List<string> strList = new List<string>();
        private Dictionary<TKey, TValue> tKeyDictionary = new Dictionary<TKey, TValue>();
        private Dictionary<string, TValue> strDictionary = new Dictionary<string, TValue>();
        private GenerateElement<TKey, TValue> generateElement;

        public TestCollections(int count, GenerateElement<TKey, TValue> j)
        {
            generateElement = j;
            for (int i = 0; i < count; i++)
            {
                var elem = generateElement(i);
                tKeyDictionary.Add(elem.Key, elem.Value);
                strDictionary.Add(elem.Key.ToString(), elem.Value);
                tKeyList.Add(elem.Key);
                strList.Add(elem.Key.ToString());
            }
        }

        #region Search Methods

         public void searchKeyList()
        {
            Console.WriteLine("\nIn Key List \nTime of the search:\n");

            var first = tKeyList[0];
            var middle = tKeyList[tKeyList.Count / 2];
            var last = tKeyList[tKeyList.Count - 1];
            var none = generateElement(tKeyList.Count + 1).Key;

            var watch = Stopwatch.StartNew();
            tKeyList.Contains(first);
            watch.Stop();
            Console.WriteLine("For the first element: " + watch.Elapsed.Ticks);

            watch.Restart();
            tKeyList.Contains(middle);
            watch.Stop();
            Console.WriteLine("For the middle element: " + watch.Elapsed.Ticks);

            watch.Restart();
            tKeyList.Contains(last);
            watch.Stop();
            Console.WriteLine("For the last element: " + watch.Elapsed.Ticks);

            watch.Restart();
            tKeyList.Contains(none);
            watch.Stop();
            Console.WriteLine("For the element that there is no in list: " + watch.Elapsed.Ticks);
        }

        public void searchStrList()
        {
            Console.WriteLine("\nIn String List\nTime of the search:\n");

            var first = strList[0];
            var middle = strList[strList.Count / 2];
            var last = strList[strList.Count - 1];
            var none = generateElement(strList.Count + 1).Key.ToString();

            var watch = Stopwatch.StartNew();
            strList.Contains(first);
            watch.Stop();
            Console.WriteLine("For the first element: " + watch.Elapsed.Ticks);

            watch.Restart();
            strList.Contains(middle);
            watch.Stop();
            Console.WriteLine("For the middle element: " + watch.Elapsed.Ticks);

            watch.Restart();
            strList.Contains(last);
            watch.Stop();
            Console.WriteLine("For the last element: " + watch.Elapsed.Ticks);

            watch.Restart();
            strList.Contains(none);
            watch.Stop();
            Console.WriteLine("For the element that there is no in list: " + watch.Elapsed.Ticks);
        }

        public void searchTKeyDictionaryByKey()
        {
            Console.WriteLine("\nTKey Dictionary by Key\nTime of the search:\n");

            var first = tKeyDictionary.ElementAt(0).Key;
            var middle = tKeyDictionary.ElementAt(tKeyDictionary.Count / 2).Key;
            var last = tKeyDictionary.ElementAt(tKeyDictionary.Count - 1).Key;
            var none = generateElement(tKeyDictionary.Count + 1).Key;

            var watch = Stopwatch.StartNew();
            tKeyDictionary.ContainsKey(first);
            watch.Stop();
            Console.WriteLine("For the first element: " + watch.Elapsed.Ticks);

            watch.Restart();
            tKeyDictionary.ContainsKey(middle);
            watch.Stop();
            Console.WriteLine("For the middle element: " + watch.Elapsed.Ticks);

            watch.Restart();
            tKeyDictionary.ContainsKey(last);
            watch.Stop();
            Console.WriteLine("For the last element: " + watch.Elapsed.Ticks);

            watch.Restart();
            tKeyDictionary.ContainsKey(none);
            watch.Stop();
            Console.WriteLine("For the element that there is no in list: " + watch.Elapsed.Ticks);
        }

        public void searchStrDictionaryByKey()
        {
            Console.WriteLine("\nString Dictionary by Key\nTime of the search:\n");

            var first = strDictionary.ElementAt(0).Key;
            var middle = strDictionary.ElementAt(strDictionary.Count / 2).Key;
            var last = strDictionary.ElementAt(strDictionary.Count - 1).Key;
            var none = generateElement(strDictionary.Count + 1).Key.ToString();

            var watch = Stopwatch.StartNew();
            strDictionary.ContainsKey(first);
            watch.Stop();
            Console.WriteLine("For the first element: " + watch.Elapsed.Ticks);

            watch.Restart();
            strDictionary.ContainsKey(middle);
            watch.Stop();
            Console.WriteLine("For the middle element: " + watch.Elapsed.Ticks);

            watch.Restart();
            strDictionary.ContainsKey(last);
            watch.Stop();
            Console.WriteLine("For the last element: " + watch.Elapsed.Ticks);

            watch.Restart();
            strDictionary.ContainsKey(none);
            watch.Stop();
            Console.WriteLine("For the element that there is no in list: " + watch.Elapsed.Ticks);
        }

        public void searchTKeyDictionaryByValue()
        {
            Console.WriteLine("\nTKey Dictionary by Value\nTime of the search:\n");

            var first = tKeyDictionary.ElementAt(0).Value;
            var middle = tKeyDictionary.ElementAt(tKeyDictionary.Count / 2).Value;
            var last = tKeyDictionary.ElementAt(tKeyDictionary.Count - 1).Value;
            var none = generateElement(tKeyDictionary.Count + 1).Value;

            var watch = Stopwatch.StartNew();
            tKeyDictionary.ContainsValue(first);
            watch.Stop();
            Console.WriteLine("For the first element: " + watch.Elapsed.Ticks);

            watch.Restart();
            tKeyDictionary.ContainsValue(middle);
            watch.Stop();
            Console.WriteLine("For the middle element: " + watch.Elapsed.Ticks);

            watch.Restart();
            tKeyDictionary.ContainsValue(last);
            watch.Stop();
            Console.WriteLine("For the last element: " + watch.Elapsed.Ticks);

            watch.Restart();
            tKeyDictionary.ContainsValue(none);
            watch.Stop();
            Console.WriteLine("For the element that there is no in list: " + watch.Elapsed.Ticks);
        }

        #endregion
    }
}