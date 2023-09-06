using System;
using System.Runtime.InteropServices;

namespace CS_4
{
    class Program
    {
        static void Main(string[] args)
        {
            KeySelector<String> selector = magazine => magazine.GetHashCode().ToString();
            MagazineCollection<string> mgCollection = new MagazineCollection<string>(selector);
            mgCollection.CollectionName = "Magazine Collection";

            Magazine m1 = new Magazine();
            Magazine m2 = new Magazine("Some Name", Frequency.Monthly, new DateTime(1970,1,1), 999_999);
            Magazine m3 = new Magazine("New name", Frequency.Monthly, new DateTime(1980,1,1), 999_999);

            Listener listener = new Listener();
            // changes in collections
            mgCollection.MagazineChanged += listener.NewEntryForCollection; 

            // changes in properties
            //m1.PropertyChanged += listener.NewEntryForProperty;
            //m2.PropertyChanged += listener.NewEntryForProperty;
            
            // 1. Add new elements
            mgCollection.AddMagazine(m1);
            mgCollection.AddMagazine(m2);
            
            // 2. Change elements properties
            m1.ReleaseDate = new DateTime(2000, 1,1);
            m1.Circulation = 999;
            
            // 3. Replacing element
            mgCollection.Replace(m2, m3);
            
            // 4. Change properties of excluded element
            m2.Circulation = 10;

            Console.WriteLine("\n\n             Changes:\n");
            Console.WriteLine(listener);
        }
    }
}