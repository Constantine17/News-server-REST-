using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Hosting;
using System.IO;
using System.Text;

namespace News_server.Controllers
{
    public class cacheController : ApiController
    {
        public HttpResponseMessage get()
        {
            string directory = HostingEnvironment.ApplicationPhysicalPath;
            StreamReader xml_file = new StreamReader(directory + @"output\news.xml");

            return new HttpResponseMessage()
            {
                Content = new StringContent(xml_file.ReadToEnd(), Encoding.UTF8)
            };
        }
    }
}
