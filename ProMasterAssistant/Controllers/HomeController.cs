using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProMasterAssistant.Models;

namespace ProMasterAssistant.Controllers
{
	[MainMenu]
    public class HomeController : Controller
    {
        //
        // GET: /Home/
		ConnectionsEntities db = new ConnectionsEntities();

        public ActionResult Index()
        {
			List<UserConnectionString> connStrings = db.UserConnectionStrings.Where(x => x.UserName == User.Identity.Name).ToList();

			return View(connStrings);
        }

		[HttpPost]
		public JsonResult Add(string connName, string serverName, string databaseName, string userId, string password)
		{
			//try
			//{
			//    db.UserConnectionStrings.AddObject(
			//        new UserConnectionString { UserName = User.Identity.Name, ConnectionName = connName, ConnectionString = connString });
			//    db.SaveChanges();
			//}
			//catch (Exception e)
			//{

			//    return Json(new { status = "error", message = e.Message });
			//}

			return Json(new { status = "ok", message = "" });
		}

    }

}
