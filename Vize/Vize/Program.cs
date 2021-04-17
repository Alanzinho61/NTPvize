using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Xml;

namespace Vize
{
    class Program
    {
        //public static XElement root;
        static void Main(string[] args)
        {
            string bugun = "https://www.haberturk.com/rss";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);
            DateTime tarih = Convert.ToDateTime(xmldosya.SelectSingleNode("//pubDate").Attributes["pubDate"].Value);
            string haber = xmldosya.SelectSingleNode("pubDate/item[@kod='title']").InnerXml;
            //Console.WriteLine(tarih);
            Console.ReadKey();
        }
    }
}
