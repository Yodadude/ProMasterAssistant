using System.Web.Mvc;

namespace ProMasterAssistant.Controllers
{
	[MainMenu]
    public class GLController : Controller
    {

        public ActionResult Index()
        {
        	ViewData["menu"] = "index";
           // ViewBag.ConnectionString = HttpContext.Request.Cookies.Get("ConnectionString").Value.FromBase64();
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
