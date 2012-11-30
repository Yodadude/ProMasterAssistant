using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProMasterAssistant.Controllers
{
	[MainMenu]
    public class GLController : Controller
    {
        //
        // GET: /GL/

        public ActionResult Index()
        {
        	ViewData["menu"] = "index";
            return View();
        }

		public ActionResult Rules()
		{
			ViewData["menu"] = "rules";
			return View();
		}

		public ActionResult Segments()
		{
			ViewData["menu"] = "segments";
			return View();
		}

		public ActionResult Test()
		{
			ViewData["menu"] = "test";
			return View();
		}

		public ActionResult Reference()
		{
			return PartialView();
		}

    }
}
