using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProMasterAssistant.Models;
using NPoco;
using System.Text;
using System.Configuration;

namespace ProMasterAssistant.Controllers
{
    [MainMenu]
    public class HomeController : Controller
    {

        // GET: /Home/
        public ActionResult Index()
        {
            var list = new List<ConnectionStringsModel>();
            ViewBag.CurrentConnectionStringName = HttpContext.Request.Cookies["ConnectionStringName"] != null ? HttpContext.Request.Cookies["ConnectionStringName"].Value : "";
            //ViewBag.CurrentConnectionStringName = HttpContext.Request.Cookies["ConnectionStringName"].Value ?? "";

            for (int i = 0; i < ConfigurationManager.ConnectionStrings.Count; i++)
		    {
                list.Add(new ConnectionStringsModel
                {
                    Name = ConfigurationManager.ConnectionStrings[i].Name,
                    ConnectionString = ConfigurationManager.ConnectionStrings[i].ConnectionString
                });
			}

            return View(list);
        }

        [HttpPost]
        public JsonResult SetConnection(ConnectionSettingsModel model)
        {

            HttpContext.Response.Cookies.Remove("ConnectionStringName");

            try
            {

                var db = new Database(model.ConnectionStringName, DatabaseType.SqlServer2008);

                this.HttpContext.Response.Cookies.Add(new HttpCookie("ConnectionStringName", model.ConnectionStringName));

                return Json(new { status = "ok", message = "" });

            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message });
            }
        }
    }

}
