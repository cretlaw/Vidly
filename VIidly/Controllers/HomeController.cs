using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace VIidly.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //Sometimes browser cache pages by default to disable this you can do the following
        //[OutputCache(Duration = 0,  VaryByParam = "*", NoStore = true)]
        //Note you can also perform data caching but that may result in problems with Entity framework and DB
        [OutputCache(Duration = 50, Location = OutputCacheLocation.Server, VaryByParam ="*")]
        public ActionResult Index()
        {
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