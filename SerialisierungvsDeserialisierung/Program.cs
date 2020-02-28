using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SerialisierungvsDeserialisierung
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = new DateTime(2042, 12, 24, 18, 42, 0);
            Person person = new Person("Aouadhi", "Tarek", dt);
            Person person3 = new Person("Müller", "Janick", dt);
            Person person4 = new Person("Neumann", "Jörg", dt);


            List<Person> myList = new List<Person>();
            myList.Add(person);
            myList.Add(person3);
            myList.Add(person4);


            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(@"C:\Users\Administrator\source\repos\SerialisierungvsDeserialisierung\SerialisierungvsDeserialisierung\bin\Debug\objekt.txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, myList);
            stream.Close();
            // Deserialisierung
            stream = new FileStream(@"C:\Users\Administrator\source\repos\SerialisierungvsDeserialisierung\SerialisierungvsDeserialisierung\bin\Debug\objekt.txt", FileMode.Open, FileAccess.Read);

            List<Person> myList1 = (List<Person>)formatter.Deserialize(stream);
            person.PersonenDatenAusgabe(myList1);
            Console.ReadKey();
          
        }
    }
    [Serializable]
    class Person
    {
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public Person Mutter { get; set; }
        public Person Vater { get; set; }
        public Person Kind { get; set; }

        public Person(string nachname, string vorname, DateTime geburtsdatum)
        {
            Nachname = nachname;
            Vorname = vorname;
            Geburtsdatum = geburtsdatum;

        }
        public void PersonenDatenAusgabe(List<Person> people)
        {
            foreach (Person item in people)
            {
                Console.WriteLine(item.Nachname);
                Console.WriteLine(item.Vorname);
                Console.WriteLine(item.Geburtsdatum);
            }


        }
    }
}
