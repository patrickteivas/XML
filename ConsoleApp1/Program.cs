using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //XmlReader xmlReader = XmlReader.Create("http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml");
            //while(xmlReader.Read())
            //{
            //    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "Cube")
            //    {
            //        if(xmlReader.HasAttributes)
            //        {
            //            Console.WriteLine(xmlReader.GetAttribute("currency") +
            //                " " + xmlReader.GetAttribute("rate"));
            //        }
            //    }
            //}

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");
            foreach (XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes[2].ChildNodes[0].ChildNodes)
            {
                Console.WriteLine(xmlNode.Attributes["currency"].Value + " " + xmlNode.Attributes["rate"].Value);
            }
        }
    }
}
