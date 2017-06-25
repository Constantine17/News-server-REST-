using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Hosting;
using System.IO;
using System.Text;
using News_server.News_spiders;


namespace News_server.Controllers
{
    public class refreshController : ApiController
    {
        public HttpResponseMessage get()
        {
            Global_collection collection = new Global_collection();
            Spiders spider = new Spiders();

            collection.add(spider.theverge_com());
            collection.inXml();

            string directory = HostingEnvironment.ApplicationPhysicalPath;
            StreamReader xml_file = new StreamReader(directory + @"output\news.xml");

            return new HttpResponseMessage()
            {
                Content = new StringContent(xml_file.ReadToEnd(), Encoding.UTF8)
            };
        }
    }
}
