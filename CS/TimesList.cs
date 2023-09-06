using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CSharp
{
    public class TimesList
    {
        private List<TimeItem> items = new List<TimeItem>();

        public void Add(TimeItem item)
        {
            items.Add(item);
        }

        public void Save(string filename)
        {
            try
            {
                var formatter = new BinaryFormatter();
                using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, items);
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error in TimeItem's list serialization");
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }

        public void Load(string filename)
        {
            try
            {
                var formatter = new BinaryFormatter();
                using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    items = formatter.Deserialize(fs) as List<TimeItem>;
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error in TimeItem's list deserialization");
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in items)
            {
                sb.Append(item);
            }

            return sb.ToString();
        }
    }
}