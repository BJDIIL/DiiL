using diil.web.Services.Interface;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace diil.web.Controllers
{
    public class ValuesController : ApiController
    {
        private IService _service;
        ILog _log;

        //log.Info(DateTime.Now.ToString() + ": login success");//写入一条新log
        public ValuesController(IService service, ILog log)
        {
            this._service = service;
            this._log = log;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            try
            {
                this._log.Info("test log4net autofac IoC");
            }
            catch (Exception ex)
            {

                throw;
            }
            
            return new string[] { "value1", "value2", _service.Say("刘帅") };
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
