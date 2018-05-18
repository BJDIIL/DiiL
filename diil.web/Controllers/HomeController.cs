using DiiL.Core.Extensions;
using DiiL.Services.Articles;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace diil.web.Controllers
{
    public class HomeController : Controller
    {
        private IArticleService _service;
        ILog _log;
        public HomeController(IArticleService service, ILog log)
        {
            this._service = service;
            this._log = log;
        }

        [OutputCache(Duration = 10)]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            Response.Write("487".ToCapitalRMB());

            return View();
        }
    }
}
