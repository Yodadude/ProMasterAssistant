using System.Web.Mvc;
using NPoco;
using ProMasterAssistant.Models;
using System.Collections.Generic;
using ProMasterAssistant.Infrastructure;

namespace ProMasterAssistant.Controllers
{
	[MainMenu]
    public class GLController : BaseController
    {

        public ActionResult Index()
        {

            var sql = @"select * from gl_type";

            var rows = DataContext.Fetch<Domain.GlType>(sql);

            var model = new GlTypesListViewModel
            {
                GlTypes = rows
            };

            return View(model);
        }

		public ActionResult Rules()
		{
			return View();
		}

		public ActionResult Segments()
		{
			return View();
		}

		public ActionResult Test()
		{
			return View();
		}

		public ActionResult Reference()
		{
			return PartialView();
		}

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var items = new List<MenuItem>
            {
                new MenuItem{ Text = "Types", Action = "Index", Controller = "GL", Selected=false },
                new MenuItem{ Text = "Segments", Action = "Segments", Controller = "GL", Selected = false},
                new MenuItem{ Text = "Rules", Action = "Rules", Controller = "GL", Selected = false },
                new MenuItem{ Text = "Test", Action = "Test", Controller = "GL", Selected = false }
            };

            MenuHelper.SetActive(ControllerContext, items);

            return PartialView("_Menu", items);
        }

    }


}
