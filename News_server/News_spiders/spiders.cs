using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Collections.ObjectModel;
//using HtmlAgilityPack;


namespace News_server.News_spiders
{
    public class Spiders : news
    {
        public int id { get; set; }
        public string type { get; set; }
        public string sourse { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string image { get; set; }

        public Collection<news> theverge_com()
        {
            Debug.WriteLine("recvest time({0})", DateTime.Now);

            //Collection_news theverge = new Collection_news();
            Collection<news> collection_news = new Collection<news>();

            WebRequest request = WebRequest.Create(@"https://www.theverge.com/");
            WebResponse response = request.GetResponse();
            StreamReader page = new StreamReader(response.GetResponseStream());
            string html = page.ReadToEnd();

            // get data on the main page
            string regular_class = @"(?inx)<div \s class \s* = \s*(?<q> ['""] )(c-compact-river__entry [^""]+ )\k<q>[^>]* >";
            string regular_pruf = @"(?inx)<a \s [^>]*href \s* = \s*(?<q> ['""] )(?<url> [^""]+ )\k<q>[^>]* >";
            string regular_img = @"(?inx)<img \s src \s* = (?<q> ['""] )(?<url> [^""]+)";
            string regular_title = @"(?inx)<h2 \s class \s* = \s*(?<q>['""]c-entry-box--compact__title[""]+)(.*href=)([""].*[""]>)(?<title> [^<]+)";

            Regex search_blok = new Regex(regular_class);
            Regex search_pruf = new Regex(regular_pruf);
            Regex search_img = new Regex(regular_img);
            Regex search_title = new Regex(regular_title);

            Match match;
            foreach (Match all_classes in search_blok.Matches(html))
            {
                match = search_pruf.Match(html, all_classes.Index);
                sourse = match.Groups["url"].ToString();
                match = search_img.Match(html, all_classes.Index);
                image = match.Groups["url"].ToString();
                match = search_title.Match(html, all_classes.Index);
                title = match.Groups["title"].ToString();
                type = "technology";// site heve only the type news


                /// get data on the news page{
                WebRequest request_news = WebRequest.Create(sourse);
                WebResponse response_news = request_news.GetResponse();
                StreamReader page_news = new StreamReader(response_news.GetResponseStream());
                string html_news = page_news.ReadToEnd();

                string regular_content = @"(?inx)<meta \s name\s*= \s*(?<q>['""]description[""]) \s* content=[""](?<content> [^""]+)";
                Regex search_content = new Regex(regular_content);
                match = search_content.Match(html_news);
                content = match.Groups["content"].ToString();
                ///  get data on the news page}

                news element = new object_news();
                element.type = type;
                element.sourse = sourse;
                element.title = title;
                element.content = content;
                element.image = image;
                collection_news.Add(element);

                Debug.WriteLine(sourse);
                Debug.WriteLine(image);
                Debug.WriteLine(title);
                Debug.WriteLine(content);
                Debug.WriteLine(type);
                Debug.WriteLine("---------------------------");
            }

            Debug.WriteLine("recvest time({0})", DateTime.Now);
           return collection_news;
        }


        public void debug()
        {
            this.theverge_com();

            Debug.WriteLine(id);
            Debug.WriteLine(type);
            Debug.WriteLine(sourse);
            Debug.WriteLine(title);
            Debug.WriteLine(content);
            Debug.WriteLine(image);
        }
    }

}