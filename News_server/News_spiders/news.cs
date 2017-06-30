
using System;

namespace News_server.News_spiders
{
    public interface news
    {
        int id { get; set; }
        string type { get; set; }
        string source { get; set; }
        string title { get; set; }
        string content { get; set; }
        string image { get; set; }
    }

    public class object_news : news
    {
        public int id { get; set ; }
        public string type { get; set; }
        public string source { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string image { get; set; }
    }

}