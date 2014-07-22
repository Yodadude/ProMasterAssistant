using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProMasterAssistant.Infrastructure;

namespace ProMasterAssistant.Controllers
{
    public class SharedController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var currentController = HttpContext.Request.RequestContext.RouteData.Values["controller"].ToString();
            bool IsConnectionStringDefined = HttpContext.Request.Cookies.AllKeys.Contains("ConnectionStringName");

            var items = new List<MenuItem>
            {
                new MenuItem{ Text = "Database", Action = "Index", Controller = "Home", Selected = (currentController=="Home") },
                new MenuItem{ Text = "Activity", Action = "Index", Controller = "Activity", Selected = (currentController=="Activity")},
                new MenuItem{ Text = "Workflow", Action = "Index", Controller = "Workflow", Selected = (currentController=="Workflow") },
                new MenuItem{ Text = "GL", Action = "Index", Controller = "GL", Selected = (currentController=="GL") }
            };

            if (!IsConnectionStringDefined)
            {
                items = items.Where(x => x.Text.Equals("Database")).ToList();
            }

            return PartialView(items);
        }

    }
}
