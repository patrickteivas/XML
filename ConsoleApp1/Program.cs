using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

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

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("test-doc.xml");
            XmlNodeList userNodes = xmlDoc.SelectNodes("//users/user");
            foreach (XmlNode userNode in userNodes)
            {
                int age = int.Parse(userNode.Attributes["age"].Value);
                userNode.Attributes["age"].Value = (age + 1).ToString();
            }
            xmlDoc.Save("test-doc.xml");
        }
    }
}
