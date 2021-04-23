using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace Vize
{
    class Program
    {
        public static XElement root;
        public static XMLGET xml = new XMLGET();
        static void Main(string[] args)
        {
            XMLGET.ac();
            XMLGET.yazdir();
            XMLGET.kaydet();   
            Console.ReadKey();
            
        }
        public class XMLGET
        {
            public static void ac()
            {
                XmlDocument yenixml = new XmlDocument();
                yenixml.Load("Haberturk.Xml");
            }
            public static void yazdir()
            {
                XmlDocument cekilecekxml = new XmlDocument();
                cekilecekxml.Load("https://www.haberturk.com/rss");

                XElement root = XElement.Load("Haberturk.Xml");

                root.RemoveAll();
                foreach (XmlNode item in cekilecekxml.SelectNodes("rss/channel/item"))
                {
                    Console.WriteLine(item["title"].InnerText);

                    XElement medya = new XElement("medya");
                    XElement baslik = new XElement("baslik");

                    baslik.Value = item["title"].InnerText;

                    medya.Add(baslik);
                    root.Add(medya);

                }
             
            }
            public static void kaydet()
            {
                XElement root = XElement.Load("Haberturk.Xml");
                root.Save("Haberturk.Xml");
            }
        }

        
    }
}
