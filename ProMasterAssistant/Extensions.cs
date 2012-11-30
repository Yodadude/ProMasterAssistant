using System.Web;
using System.Web.Mvc;

namespace ProMasterAssistant
{
	public static class Extensions
	{
		public static MvcHtmlString ActiveMenu(this HtmlHelper helper, string menuName)
		{
			string result = "";
			string currentMenuName = helper.ViewData["MainMenuActive"] as string;

			if ((menuName == "Database" && currentMenuName == "Home") ||
				(menuName == "Activity" && currentMenuName == "Activity") ||
				(menuName == "Workflow" && currentMenuName == "Workflow") ||
				(menuName == "GL" && currentMenuName == "GL"))
				result = "class=\"active\"";

			return MvcHtmlString.Create(result);
		}
	}
}