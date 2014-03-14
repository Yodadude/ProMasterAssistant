using System.Web.Mvc;
using NPoco;
using ProMasterAssistant.Models;

namespace ProMasterAssistant.Controllers
{
	[MainMenu]
    public class GLController : Controller
    {

        public ActionResult Index()
        {
        	ViewData["menu"] = "index";

            var connectionString = HttpContext.Request.Cookies.Get("ConnectionString").Value.FromBase64();

            var db = new Database(connectionString, DatabaseType.SqlServer2008);

            var sql = @"select * from gl_type";

            var rows = db.Fetch<Domain.GlType>(sql);

            var model = new GlTypesListViewModel
            {
                GlTypes = rows
            };

            return View(model);
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
