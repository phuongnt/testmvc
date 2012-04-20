using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pnet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            pnet.Models.Portal oportal = new Models.Portal();
            oportal.ID = 1;
            oportal.Name = "conmeno";
            //oportal.Products.Add(new Models.Product(1, "product1"));
            //oportal.Products.Add(new Models.Product(2, "product1"));
            //oportal.Products.Add(new Models.Product(3, "product2"));

            Models.Product oproduct = new Models.Product();
            oproduct.ID = 32;
            oproduct.Name = "phuong";

            string temp = "";


            temp = pnet.Models.Utility.Serialize(oproduct, true);

            ViewBag.hehe = temp;
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
    }

    public class Conmeno
    {
        public string xx;
        public string xy;
    }
}