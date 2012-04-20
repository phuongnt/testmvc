using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace pnet.Controllers
{
    public class CMDController : Controller
    {
        //
        // GET: /CMD/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RenderModule()
        {

            string abc = RenderRazorViewToString("Partial1"); 
            return Json(abc );
        }

        private string RenderRazorViewToString(string viewName)
        {
            using (var sw = new System.IO.StringWriter())
            {
                var viewResult =
                ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext =
                new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
      

      



    }
}
