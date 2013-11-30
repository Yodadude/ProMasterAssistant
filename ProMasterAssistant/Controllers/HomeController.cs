using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProMasterAssistant.Models;
using NPoco;
using System.Text;

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
                string connectionString = String.Format("Server={0};Database={1};User Id={2};Password={3};", model.Server, model.Database, model.UserId, model.Password);

                var db = new Database(connectionString, DatabaseType.SqlServer2008);

                this.HttpContext.Response.Cookies.Add(new HttpCookie("ConnectionString", connectionString.ToBase64()));
								
			}
			catch (Exception e)
			{
			    return Json(new { status = "error", message = e.Message });
			}

			return Json(new { status = "ok", message = "" });
		}


    }

}
