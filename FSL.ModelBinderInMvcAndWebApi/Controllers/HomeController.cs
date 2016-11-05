using FSL.ModelBinderInMvcAndWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FSL.ModelBinderInMvcAndWebApi.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(EnvironmentInfo environmentInfo)
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