using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialize_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            BooksWorker bwork = new BooksWorker();
            bwork.AddBook("NewAmazingBook", "Unnamed", "Player", 222, 1998);
            bwork.AddBook("Random Book", "Zero", "One", 5435, 2007);
            bwork.AddBook("The secret story", "Player", "1", 3, 2018);


            bwork.SaveToBinary(AppDomain.CurrentDomain.BaseDirectory + "a.bin");
            Console.WriteLine("\nReading from Binary\n");
            bwork.ReadFromBinary(AppDomain.CurrentDomain.BaseDirectory + "a.bin");

            bwork.SaveToJSON_DataContract(AppDomain.CurrentDomain.BaseDirectory + "a.json");
            Console.WriteLine("\nReading from JSON\n");
            bwork.ReadFromJSON_DataContract(AppDomain.CurrentDomain.BaseDirectory + "a.json");

            bwork.SaveToXML(AppDomain.CurrentDomain.BaseDirectory + "a.xml");
            Console.WriteLine("\nReading from XML\n");
            bwork.ReadFromXML(AppDomain.CurrentDomain.BaseDirectory + "a.xml");
        }
    }
}
