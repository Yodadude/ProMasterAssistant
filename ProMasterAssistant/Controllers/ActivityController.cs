using ProMasterAssistant.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProMasterAssistant.Controllers
{
	[MainMenu]
    public class ActivityController : Controller
    {
        //
        // GET: /Activity/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MapperSource()
        {
            return View();
        }

        public ActionResult XslSource()
        {
            return View();
        }

        public ActionResult SqlActions()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var items = new List<MenuItem>
            {
                new MenuItem{ Text = "Parameters", Action = "Index", Controller = "Activity", Selected=false },
                new MenuItem{ Text = "Mapper Source", Action = "MapperSource", Controller = "Activity", Selected = false},
                new MenuItem{ Text = "XSL Source", Action = "XslSource", Controller = "Activity", Selected = false },
                new MenuItem{ Text = "SQL Actions", Action = "SqlActions", Controller = "Activity", Selected = false }
            };

            MenuHelper.SetActive(ControllerContext, items);

            return PartialView("_Menu", items);
        }

    }
}
