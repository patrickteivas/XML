using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckAndLoad();
            MenuOptions();
        }

        static void CheckAndLoad()
        {
            List<Note> Notes = new List<Note>();
            XmlSerializer Serializer = new XmlSerializer(typeof(List<Note>));

            if (!(File.Exists("../../Notes.xml")))
            {
                using (var Writer = XmlWriter.Create("../../Notes.xml"))
                {
                    Serializer.Serialize(Writer, Notes);
                }
            }
        }

        static void MenuOptions()
        {
            List<Note> Notes = new List<Note>();
            XmlSerializer Serializer = new XmlSerializer(typeof(List<Note>));
            using (var Reader = XmlReader.Create("../../Notes.xml"))
            {
                Notes = (List<Note>)Serializer.Deserialize(Reader);
            }

            Console.Clear();
            Console.WriteLine("Mida soovite teha?\n1) Lugeda märkmeid\n2) Koostada märge\n3) Kustutada märge");

            bool Result = false;
            int Valik = 0;

            while (Result == false)
            {
                Result = int.TryParse(Console.ReadLine(), out Valik);

                if (Result == false) Console.WriteLine("Vale valik");
                else if (Valik < 1 | Valik > 3)
                {
                    Console.WriteLine("Vale valik");
                    Result = false;
                }
            }

            Console.Clear();

            if (Valik == 1) ReadNotes();
            else if (Valik == 2) CreateNote();
            else if (Valik == 3) DeleteNote();
        }

        static void ReadNotes()
        {
            List<Note> Notes = new List<Note>();
            XmlSerializer Serializer = new XmlSerializer(typeof(List<Note>));
            using (var Reader = XmlReader.Create("../../Notes.xml"))
            {
                Notes = (List<Note>)Serializer.Deserialize(Reader);
            }

            if (Notes.Count == 0)
            {
                Console.WriteLine("Teil pole märkmeid");

                ExitOrContinue();
            }
            else
            {
                Console.WriteLine("Sisestage number avamiseks:");

                int i = 0;

                foreach (var item in Notes)
                {
                    i++;
                    Console.WriteLine(i + ") " + item.Name);
                }

                bool Result = false;
                int Valik = 0;

                while (Result == false)
                {
                    Result = int.TryParse(Console.ReadLine(), out Valik);

                    if (Result == false) Console.WriteLine("Vale valik");
                    else if (Valik < 1 | Valik > Notes.Count)
                    {
                        Console.WriteLine("Vale valik");
                        Result = false;
                    }
                }

                Console.Clear();
                Console.WriteLine("Märkme " + Notes[Valik - 1].Name + " sisu:\n" + Notes[Valik - 1].Content);
            }

            ExitOrContinue();
        }

        static void CreateNote()
        {
            List<Note> Notes = new List<Note>();
            XmlSerializer Serializer = new XmlSerializer(typeof(List<Note>));
            using (var Reader = XmlReader.Create("../../Notes.xml"))
            {
                Notes = (List<Note>)Serializer.Deserialize(Reader);
            }

            bool State = true;

            while (State == true)
            {
                Console.WriteLine("Sisestage märkme nimetus");
                string Name = Console.ReadLine();
                Console.WriteLine("Sisestage märkme sisu");
                string Content = Console.ReadLine();

                if (Name != "" && Content != "")
                {
                    Notes.Add(new Note() { Name = Name, Content = Content });
                    using (var Writer = XmlWriter.Create("../../Notes.xml"))
                    {
                        Serializer.Serialize(Writer, Notes);
                    }
                    State = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Te ei sisestanud midagi");
                }
            }

            MenuOptions();
        }

        static void DeleteNote()
        {
            List<Note> Notes = new List<Note>();
            XmlSerializer Serializer = new XmlSerializer(typeof(List<Note>));
            using (var Reader = XmlReader.Create("../../Notes.xml"))
            {
                Notes = (List<Note>)Serializer.Deserialize(Reader);
            }


            if (Notes.Count == 0)
            {
                Console.WriteLine("Teil pole märkmeid");

                ExitOrContinue();
            }
            else
            {
                Console.WriteLine("Sisestage number kustutamiseks:");

                int i = 0;

                foreach (var item in Notes)
                {
                    i++;
                    Console.WriteLine(i + ") " + item.Name);
                }

                bool Result = false;
                int Valik = 0;

                while (Result == false)
                {
                    Result = int.TryParse(Console.ReadLine(), out Valik);

                    if (Result == false) Console.WriteLine("Vale valik");
                    else if (Valik < 1 | Valik > Notes.Count)
                    {
                        Console.WriteLine("Vale valik");
                        Result = false;
                    }
                }

                Notes.RemoveAt(Valik - 1);
                using (var Writer = XmlWriter.Create("../../Notes.xml"))
                {
                    Serializer.Serialize(Writer, Notes);
                }
            }
            Console.Clear();
            MenuOptions();
        }

        static void ExitOrContinue()
        {
            bool Result = false;
            string Valik;

            Console.WriteLine("Soovite jätkata programmi kasutusega? (Y/N)");

            while (Result == false)
            {
                Valik = Console.ReadLine().ToLower();
                if (Valik == "y") MenuOptions();
                else if (Valik == "n")
                {
                    Console.Clear();
                    Console.WriteLine("Programm lõpetas töö");
                    Environment.Exit(0);
                }
                else Console.WriteLine("Vale valik");
            }
        }
    }

    public class Note
    {
        public string Name { get; set; }
        public string Content { get; set; }
    }
}

