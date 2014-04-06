using ProMasterAssistant.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProMasterAssistant.Controllers
{
	[MainMenu]
    public class WorkflowController : Controller
    {
        //
        // GET: /Workflow/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CallDefinitions()
        {
            return View();
        }

        public ActionResult EntryDefinitions()
        {
            return View();
        }

        public ActionResult Map()
        {
            return View();
        }

        public ActionResult ActivityTypes()
        {
            return View();
        }

        public ActionResult Messages()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var items = new List<MenuItem>
            {
                new MenuItem{ Text = "Activities", Action = "Index", Controller = "Workflow", Selected=false },
                new MenuItem{ Text = "Call Definitions", Action = "CallDefinitions", Controller = "Workflow", Selected = false},
                new MenuItem{ Text = "Entry Definitions", Action = "EntryDefinitions", Controller = "Workflow", Selected = false },
                new MenuItem{ Text = "Map", Action = "Map", Controller = "Workflow", Selected = false },
                new MenuItem{ Text = "Activity Types", Action = "ActivityTypes", Controller = "Workflow", Selected = false },
                new MenuItem{ Text = "Messages", Action = "Messages", Controller = "Workflow", Selected = false },
            };

            MenuHelper.SetActive(ControllerContext, items);

            return PartialView("_Menu", items);
        }

    }
}
