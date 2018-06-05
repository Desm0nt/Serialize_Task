using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Serialize_Task
{
    public class BooksWorker
    {
        List<Book> Book;

        public BooksWorker()
        {
            Book = new List<Book>();
        }

        public void AddBook(string bookname, string fname, string lname, int pcount, int pyear)
        {
            Book.Add(new Book { Bookname = bookname, AFirstName = fname, ALastName = lname, PageCount = pcount, PublishYear = pcount });
        }

        public void SaveToXML(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            string xml;
            using (StringWriter stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, Book);
                xml = stringWriter.ToString();
            }
            File.WriteAllText(path, xml);
        }

        public void ReadFromXML(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            string xml = File.ReadAllText(path);
            using (StringReader stringReader = new StringReader(xml))
            {
                List<Book> books = (List<Book>)serializer.Deserialize(stringReader);
                foreach (var book in books)
                {
                    Console.WriteLine("Book's name: {0}\nAuthor: {1} {2}\nPage count: {3}\nPublish year: {4}\n", book.Bookname, book.AFirstName, book.ALastName, book.PageCount, book.PublishYear);
                }
            }
            Console.Read();
        }

        public void SaveToBinary(string path)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(stream, Book);
            }  
        }

        public void ReadFromBinary(string path)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(path, FileMode.Open))
            {
                List<Book> books = (List<Book>)formatter.Deserialize(stream);
                foreach (var b in books)
                {
                    string Bookname = b.Bookname;
                    string AFirstName = b.AFirstName;
                    string ALastName = b.ALastName;
                    string PageCount = b.PageCount.ToString();
                    string PublishYear = b.PublishYear.ToString();
                    Console.WriteLine("Book's name: " + Bookname + "\nAuthor: " + AFirstName + " " + ALastName + "\nPage count: " + PageCount + "\nPublish year: " + PublishYear + "\n");
                }
            }                     
        }

        public void SaveToJSON_DataContract(string path)
        {
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Book>));
                ser.WriteObject(stream, Book);
            }
        }

        public void ReadFromJSON_DataContract(string path)
        {
            using (Stream stream = new FileStream(path, FileMode.Open))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Book>));
                List<Book> books = (List<Book>)ser.ReadObject(stream);
                foreach (var b in books)
                {
                    string Bookname = b.Bookname;
                    string AFirstName = b.AFirstName;
                    string ALastName = b.ALastName;
                    string PageCount = b.PageCount.ToString();
                    string PublishYear = b.PublishYear.ToString();
                    Console.WriteLine("Book's name: " + Bookname + "\nAuthor: " + AFirstName + " " + ALastName + "\nPage count: " + PageCount + "\nPublish year: " + PublishYear + "\n");
                }
            }
        }
    }
}
