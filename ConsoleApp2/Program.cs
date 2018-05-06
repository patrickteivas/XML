using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool State = true;
            bool State2;
            var Notes = new List<Note>();

            while (State == true)
            {
                Notes = new List<Note>();
                var Serializer = new XmlSerializer(typeof(List<Note>));
                using (var Reader = XmlReader.Create("../../Notes.xml"))
                {
                    Notes = (List<Note>)Serializer.Deserialize(Reader);
                }

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

                if (Valik == 1)
                {
                    if (Notes.Count == 0)
                    {
                        Console.WriteLine("Teil pole märkmeid");
                        Console.WriteLine("Soovite jätkata programmi kasutusega? (Y/N)");
                        bool Result3 = false;
                        string Valik3;
                        while (Result3 == false)
                        {
                            Valik3 = Console.ReadLine().ToLower();
                            if (Valik3 == "y") Result3 = true;
                            else if (Valik3 == "n")
                            {
                                Result3 = true;
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

                        bool Result2 = false;
                        int Valik2 = 0;

                        while (Result2 == false)
                        {
                            Result2 = int.TryParse(Console.ReadLine(), out Valik2);

                            if (Result2 == false) Console.WriteLine("Vale valik");
                            else if (Valik2 < 1 | Valik2 > Notes.Count)
                            {
                                Console.WriteLine("Vale valik");
                                Result2 = false;
                            }
                        }

                        Console.Clear();

                        Console.WriteLine("Märkme " + Notes[Valik2 - 1].Name + " sisu:\n" + Notes[Valik2 - 1].Content);
                        Console.WriteLine("Soovite jätkata programmi kasutusega? (Y/N)");
                        bool Result3 = false;
                        string Valik3;
                        while (Result3 == false)
                        {
                            Valik3 = Console.ReadLine().ToLower();
                            if (Valik3 == "y") Result3 = true;
                            else if (Valik3 == "n")
                            {
                                Result3 = true;
                                State = false;
                            }
                            else Console.WriteLine("Vale valik");
                        }
                    }
                    Console.Clear();
                }
                else if (Valik == 2)
                {
                    State2 = true;
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
                        bool Result3 = false;
                        string Valik3;
                        while (Result3 == false)
                        {
                            Valik3 = Console.ReadLine().ToLower();
                            if (Valik3 == "y") Result3 = true;
                            else if (Valik3 == "n")
                            {
                                Result3 = true;
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

                        bool Result2 = false;
                        int Valik2 = 0;

                        while (Result2 == false)
                        {
                            Result2 = int.TryParse(Console.ReadLine(), out Valik2);

                            if (Result2 == false) Console.WriteLine("Vale valik");
                            else if (Valik2 < 1 | Valik2 > Notes.Count)
                            {
                                Console.WriteLine("Vale valik");
                                Result2 = false;
                            }
                        }

                        Notes.RemoveAt(Valik2 - 1);
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

        public void Check()
        {

        }
    }
    
    public class Note
    {
        public string Name { get; set; }
        public string Content { get; set; }
    }
}

