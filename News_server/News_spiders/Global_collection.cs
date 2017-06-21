using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using System.Text;
using System.Web.Hosting;
using System.Diagnostics;

namespace News_server.News_spiders
{
    public class Global_collection
    {
        Collection<news> all_news = new Collection<news>();
        string directory { get; set; }
        int id;

        public Global_collection()
        {
            directory = HostingEnvironment.ApplicationPhysicalPath;
            id = 1;
        }
        public Global_collection(string floder)
        {
            directory = floder;
            id = 1;
        }

        public void add(Collection<news> collection)
        {
            foreach(var element in collection)
            {
                element.id = this.id;
                id++;
                all_news.Add(element); }
        }

        public Collection<news> get()
        { return all_news; }

        public void inTxt()
        {
            Debug.WriteLine(directory);
            StreamWriter file = new StreamWriter(directory+ @"output\news.txt");
            file.WriteLine("Begin");
            for (int i = 0; i < all_news.Count; i++)
            {
                file.WriteLine("id: {0}", all_news[i].id.ToString());
                file.WriteLine("Type: {0}", all_news[i].type);
                file.WriteLine("Sourse: {0}", all_news[i].sourse);
                file.WriteLine("Title: {0}", all_news[i].title);
                file.WriteLine("Content: {0}", all_news[i].content);
                file.WriteLine("Image: {0}", all_news[i].image);
                file.WriteLine("----------------------------------------------------");
            }
            file.Close();
        }

        public void inXml()
        {
            Debug.WriteLine(directory);
            XmlTextWriter file = new XmlTextWriter(directory+ @"output\news.xml", Encoding.UTF8);
            for (int i = 0; i < all_news.Count; i++)
            {
                file.WriteStartElement("news");//<news>
                file.WriteAttributeString("id", all_news[i].id.ToString());
                file.WriteAttributeString("type", all_news[i].type);
                file.WriteAttributeString("sourse", all_news[i].sourse);
                file.WriteAttributeString("title", all_news[i].title);
                file.WriteAttributeString("content", all_news[i].content);
                file.WriteAttributeString("image", all_news[i].image);
                file.WriteEndElement();//</news>
                file.WriteWhitespace("\n");
            }
            file.Close();
        }
    }
}