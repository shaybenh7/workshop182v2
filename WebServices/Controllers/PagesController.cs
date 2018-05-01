using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebServices.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AllProducts()
        {
            return View();
        }

        public ActionResult AllStores()
        {
            return View();
        }

        public ActionResult MyStores()
        {
            return View();
        }

        public ActionResult admin()
        {
            return View();
        }

        public ActionResult register()
        {
            return View();
        }
    }
}