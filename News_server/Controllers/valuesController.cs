using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using News_server.News_spiders;

namespace News_server.Controllers
{
    public class valuesController : ApiController
    {
        // GET: api/values
        public List<object_news> Get()
        {
            try {
                Spiders spider = new Spiders();
                Global_collection collections = new Global_collection();

                collections.add(spider.theverge_com());

                return collections.getList();
            }
            catch {
                Global_collection collections = new Global_collection();
                collections.readXml();

                return collections.getList();
            }
        }

        // GET: api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/values/5
        public void Delete(int id)
        {
        }
    }
}
