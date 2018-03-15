using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CYJ.Models;

namespace CYJ.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {

            return View();
        }

        public ActionResult Added()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult ServiceDelivery()
        {
            return View();
        }
        public ActionResult CorpMemberExperience()
        {
            return View();
        }
        public ActionResult ExternalAffairs()
        {
            return View();
        }
        public ActionResult Revenue()
        {
            return View();
        }
        public ActionResult OpEx()
        {
            return View();
        }
        public ActionResult RAD()
        {
            return View();
        }
    }
}