using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZooApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var secret = ConfigurationManager.AppSettings["secretPassword"];
            ViewBag.Secret = secret;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}