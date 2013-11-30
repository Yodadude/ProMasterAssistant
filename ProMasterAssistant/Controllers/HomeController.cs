using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProMasterAssistant.Models;

namespace ProMasterAssistant.Controllers
{
	[MainMenu]
    public class HomeController : Controller
    {

        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public JsonResult SetConnection(ConnectionSettingsModel model)
		{

			try
			{
								
			}
			catch (Exception e)
			{
			    return Json(new { status = "error", message = e.Message });
			}

			return Json(new { status = "ok", message = "" });
		}


    }

}
