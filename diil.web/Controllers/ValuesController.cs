using DiiL.Services.Articles;
using log4net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;

namespace diil.web.Controllers
{
    public class ValuesController : ApiController
    {
        private IArticleService _service;
        ILog _log;
        public ValuesController(IArticleService service, ILog log)
        {
            this._service = service;
            this._log = log;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            var articles = this._service.SearchArticles();
            this._log.Info(articles);

            return new string[] { "value1", "value2", JsonConvert.SerializeObject(articles) };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
