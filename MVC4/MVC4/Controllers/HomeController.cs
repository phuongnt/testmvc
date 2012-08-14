using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your quintessential app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your quintessential contact page.";

            return View();
        }
      
        
        public JsonResult hehe()
        {
            
            //abc cde = new abc();
            //cde.name = "phuong";
            //cde.value = "xx";
            //string a = "{\"name\":\"haha\"}";
            //return Json(cde, JsonRequestBehavior.AllowGet);
            return Json("",JsonRequestBehavior.AllowGet);
        }
        abstract class abc
        {
            public string name { get; set; }
            public string value { get; set; }

            public abstract void abcd();
             

        }
        interface hehee
        {
            
        }

    }
}
