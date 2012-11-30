using System.Web.Mvc;

namespace ProMasterAssistant
{
	public class MainMenuAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			base.OnActionExecuted(filterContext);
			filterContext.Controller.ViewData["MainMenuActive"] = filterContext.RouteData.GetRequiredString("controller");
		}
	}
}