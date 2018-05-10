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

            bool State = true;
            bool Result = false;
            int Valik = 0;
            string Valik2;
            List<Note> Notes = new List<Note>();

            while (State == true)
            {
                Notes = new List<Note>();
                var Serializer = new XmlSerializer(typeof(List<Note>));
                using (var Reader = XmlReader.Create("../../Notes.xml"))
                {
                    Notes = (List<Note>)Serializer.Deserialize(Reader);
                }

                Console.WriteLine("Mida soovite teha?\n1) Lugeda märkmeid\n2) Koostada märge\n3) Kustutada märge");

                Result = false;

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

                if (Valik == 1)
                {
                    if (Notes.Count == 0)
                    {
                        Console.WriteLine("Teil pole märkmeid");
                        Console.WriteLine("Soovite jätkata programmi kasutusega? (Y/N)");
                        Result = false;
                        while (Result == false)
                        {
                            Valik2 = Console.ReadLine().ToLower();
                            if (Valik2 == "y") Result = true;
                            else if (Valik2 == "n")
                            {
                                Result = true;
                                State = false;
                            }
                            else Console.WriteLine("Vale valik");
                        }
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

                        Result = false;
                        Valik = 0;

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
                        Console.WriteLine("Soovite jätkata programmi kasutusega? (Y/N)");
                        Result = false;
                        while (Result == false)
                        {
                            Valik2 = Console.ReadLine().ToLower();
                            if (Valik2 == "y") Result = true;
                            else if (Valik2 == "n")
                            {
                                Result = true;
                                State = false;
                            }
                            else Console.WriteLine("Vale valik");
                        }
                    }
                    Console.Clear();
                }
                else if (Valik == 2)
                {
                    bool State2 = true;
                    while (State2 == true)
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
                            State2 = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Te ei sisestanud midagi");
                        }
                    }
                    Console.Clear();
                }
                else if (Valik == 3)
                {
                    if (Notes.Count == 0)
                    {
                        Console.WriteLine("Teil pole märkmeid");
                        Console.WriteLine("Soovite jätkata programmi kasutusega? (Y/N)");
                        Result = false;
                        while (Result == false)
                        {
                            Valik2 = Console.ReadLine().ToLower();
                            if (Valik2 == "y") Result = true;
                            else if (Valik2 == "n")
                            {
                                Result = true;
                                State = false;
                            }
                            else Console.WriteLine("Vale valik");
                        }
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

                        Result = false;
                        Valik = 0;

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
                }
            }
            Console.WriteLine("Programm lõpetas töö");
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
    }

    public class Note
    {
        public string Name { get; set; }
        public string Content { get; set; }
    }
}

