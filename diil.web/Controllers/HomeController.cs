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
        public ActionResult Index()
        {
            var articles = this._service.SearchArticles();
            this._log.Info(articles);
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
