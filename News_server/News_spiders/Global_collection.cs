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
        
        public List<object_news> getList()
        {
            List<object_news> collection_objects = new List<object_news>();

            foreach(var element in all_news)
            {
                object_news new_object = new object_news();

                new_object.id = element.id;
                new_object.type = element.type;
                new_object.source = element.source;
                new_object.title = element.title;
                new_object.content = element.content;
                new_object.image = element.image;

                collection_objects.Add(new_object);
            }

            return collection_objects;
        }
        
        public void toTxt()
        {
            Debug.WriteLine(directory);
            StreamWriter file = new StreamWriter(directory+ @"output\news.txt");
            file.WriteLine("Begin");
            for (int i = 0; i < all_news.Count; i++)
            {
                file.WriteLine("id: {0}", all_news[i].id.ToString());
                file.WriteLine("Type: {0}", all_news[i].type);
                file.WriteLine("Source: {0}", all_news[i].source);
                file.WriteLine("Title: {0}", all_news[i].title);
                file.WriteLine("Content: {0}", all_news[i].content);
                file.WriteLine("Image: {0}", all_news[i].image);
                file.WriteLine("----------------------------------------------------");
            }
            file.Close();
        }

        public void toXml()
        {
            Debug.WriteLine(directory);
            XmlTextWriter file = new XmlTextWriter(directory+ @"output\news.xml", Encoding.UTF8);
            file.WriteStartDocument(); file.WriteWhitespace("\n");
            file.WriteStartElement("collection_news");//<collection_news>
            file.WriteWhitespace("\n");
            for (int i = 0; i < all_news.Count; i++)
            {
                file.WriteStartElement("news");//<news>
                file.WriteAttributeString("id", all_news[i].id.ToString());
                file.WriteAttributeString("type", all_news[i].type);
                file.WriteAttributeString("source", all_news[i].source);
                file.WriteAttributeString("title", all_news[i].title);
                file.WriteAttributeString("content", all_news[i].content);
                file.WriteAttributeString("image", all_news[i].image);
                file.WriteEndElement();//</news>
                file.WriteWhitespace("\n");
            }
            file.WriteEndElement();
            file.Close();
        }

        public void readXml()
        {
            all_news.Clear();
            id = 1;

            XmlTextReader file = new XmlTextReader(directory + @"output\news.xml");
            while (file.Read())
            {
                if(file.Name == "news")
                {
                    object_news add_News = new object_news();

                    add_News.id = Convert.ToInt16(file.GetAttribute("id")); id = add_News.id;
                    add_News.type = file.GetAttribute("type");
                    add_News.source = file.GetAttribute("source");
                    add_News.title = file.GetAttribute("title");
                    add_News.content = file.GetAttribute("content");
                    add_News.image = file.GetAttribute("image");

                    all_news.Add(add_News);
                }
            }

        }
    }
}