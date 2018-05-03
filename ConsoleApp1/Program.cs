using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            //XmlReader xmlReader = XmlReader.Create("http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml");
            //while (xmlReader.Read())
            //{
            //    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "Cube")
            //    {
            //        if (xmlReader.HasAttributes)
            //        {
            //            Console.WriteLine(xmlReader.GetAttribute("currency") +
            //                " " + xmlReader.GetAttribute("rate"));
            //        }
            //    }
            //}
            ////////////////////////////////////////////////////////////////////////////////////////////////////////

            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");
            //foreach (XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes[2].ChildNodes[0].ChildNodes)
            //{
            //    Console.WriteLine(xmlNode.Attributes["currency"].Value + " " + xmlNode.Attributes["rate"].Value);
            //}
            ////////////////////////////////////////////////////////////////////////////////////////////////////////

            //XmlDocument xmlDoc = new XmlDocument();
            ////xmlDoc.LoadXml("<user name=\"John Doe\">A user node </user>");
            ////Console.WriteLine(xmlDoc.DocumentElement.Name);
            ////Console.WriteLine(xmlDoc.DocumentElement.InnerText);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////

            ////xmlDoc.LoadXml("<users><user>InnderText/InnerXaml</user></users>");
            ////Console.WriteLine(xmlDoc.DocumentElement.InnerXml);
            ////Console.WriteLine(xmlDoc.DocumentElement.InnerText);
            ////Console.WriteLine(xmlDoc.DocumentElement.OuterXml);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////

            ////xmlDoc.LoadXml("<user name=\"John Doe\" age=\"42\"/>");
            ////if (xmlDoc.DocumentElement.Attributes["name"] != null)
            ////    Console.WriteLine(xmlDoc.DocumentElement.Attributes["name"].Value);
            ////if(xmlDoc.DocumentElement.Attributes["age"] != null)
            ////    Console.WriteLine(xmlDoc.DocumentElement.Attributes["age"].Value);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////

            ////var path = XDocument.Load("../../example.xml").Element("users").Element("user");
            ////var fromFile = path.Attribute("name").Value + "\n" + path.Attribute("age").Value;
            ////Console.WriteLine(fromFile);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////

            //XmlWriter xmlWriter = XmlWriter.Create("test.xml");
            //xmlWriter.WriteStartDocument();
            //xmlWriter.WriteStartElement("users");
            //xmlWriter.WriteStartElement("user");
            //xmlWriter.WriteAttributeString("age", "42");
            //xmlWriter.WriteString("John Doe");
            //xmlWriter.WriteEndElement();
            //xmlWriter.WriteStartElement("user");
            //xmlWriter.WriteAttributeString("age", "39");
            //xmlWriter.WriteString("Jane Doe");
            //xmlWriter.WriteEndDocument();
            //xmlWriter.Close();
            ////////////////////////////////////////////////////////////////////////////////////////////////////////

            //XmlDocument xmlDoc = new XmlDocument();
            //XmlNode rootNode = xmlDoc.CreateElement("users");
            //xmlDoc.AppendChild(rootNode);

            //XmlNode userNode = xmlDoc.CreateElement("user");
            //XmlAttribute attribute = xmlDoc.CreateAttribute("age");
            //attribute.Value = "42";
            //userNode.Attributes.Append(attribute);
            //userNode.InnerText = "John Doe";
            //rootNode.AppendChild(userNode);

            //userNode = xmlDoc.CreateElement("user");
            //attribute = xmlDoc.CreateAttribute("age");
            //attribute.Value = "16";
            //userNode.Attributes.Append(attribute);
            //userNode.InnerText = "Khenno Pajunurm";
            //rootNode.AppendChild(userNode);

            //xmlDoc.Save("test-doc.xml");
            ////////////////////////////////////////////////////////////////////////////////////////////////////////

            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load("test-doc.xml");
            //XmlNodeList userNodes = xmlDoc.SelectNodes("//users/user");
            //foreach (XmlNode userNode in userNodes)
            //{
            //    int age = int.Parse(userNode.Attributes["age"].Value);
            //    userNode.Attributes["age"].Value = (age + 1).ToString();
            //}
            //xmlDoc.Save("test-doc.xml");
            ////////////////////////////////////////////////////////////////////////////////////////////////////////

            //var paljuTooteid = new List<Toode>();
            //var toode1 = new Toode() { Nimi = "Banaan", Hind = "12" };
            //var toode2 = new Toode() { Nimi = "Leib", Hind = "4" };
            //var toode3 = new Toode() { Nimi = "Sai", Hind = "42" };
            //var toode4 = new Toode() { Nimi = "Fanta", Hind = "52" };
            //var toode5 = new Toode() { Nimi = "Pastakas", Hind = "222" };

            //paljuTooteid.Add(toode1);
            //paljuTooteid.Add(toode2);
            //paljuTooteid.Add(toode3);
            //paljuTooteid.Add(toode4);
            //paljuTooteid.Add(toode5);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////KIRJUTAMINE

            //var serializer = new XmlSerializer(paljuTooteid.GetType());
            //using (var writer = XmlWriter.Create("tooted.xml"))
            //{
            //    serializer.Serialize(writer, paljuTooteid);
            //}
            ////////////////////////////////////////////////////////////////////////////////////////////////////////LUGEMINE

            //var tooted = new List<Toode>();
            //var serializer = new XmlSerializer(typeof(List<Toode>));
            //using (var reader = XmlReader.Create("tooted.xml"))
            //{
            //    tooted = (List<Toode>)serializer.Deserialize(reader);
            //}

            //foreach (var item in tooted)
            //{
            //    Console.WriteLine(item.Nimi + " " + item.Hind);
            //}
        }
    }
}
