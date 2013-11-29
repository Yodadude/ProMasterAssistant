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
        //
        // GET: /Home/
		ConnectionsEntities db = new ConnectionsEntities();

        public ActionResult Index()
        {
			//List<UserConnectionString> connStrings = db.UserConnectionStrings.Where(x => x.UserName == User.Identity.Name).ToList();

			//return View(connStrings);
            return View();
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

		[HttpPost]
		public JsonResult SetConnection(ConnectionSettingsModel model)
		{

			try
			{
				//string connectionString = new System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);

				var scsb = new System.Data.SqlClient.SqlConnectionStringBuilder
				{
					DataSource = model.Server,
					InitialCatalog = model.Database,
					UserID = model.UserId,
					Password = model.Password
				};

				var ecb = new EntityConnectionStringBuilder
				{
					Metadata = "res://*/Models.ProMaster.csdl|res://*/Models.ProMaster.ssdl|res://*/Models.ProMaster.msl",
					Provider = "System.Data.SqlClient",
					ProviderConnectionString = scsb.ConnectionString
				};

				var dbpm = new ProMasterEntities(ecb.ConnectionString);
				//var dbpm = new ProMasterEntities("data source="+model.Server+";initial catalog="+model.Database+";User Id="+model.UserId+";Password="+model.Password);
			}
			catch (Exception e)
			{
			    return Json(new { status = "error", message = e.Message });
			}

			return Json(new { status = "ok", message = "" });
		}


    }

}
