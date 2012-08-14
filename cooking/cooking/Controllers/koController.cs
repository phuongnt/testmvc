using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cooking.Controllers
{
    public class koController : Controller
    {
        //
        // GET: /ko/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SimpleList()
        {
            return View();
        }

        public ActionResult SimpleGrid()
        {
            Response.Cookies.Add(new HttpCookie("xxx","hohoho"));
            ViewBag.abc = "cai j day";
            return View();
        }

    }
}
