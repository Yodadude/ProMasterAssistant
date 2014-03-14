using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProMasterAssistant
{
	public static class Extensions
	{
		public static MvcHtmlString GetActiveMainMenu(this HtmlHelper helper, string menuName)
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

        public static String ToBase64(this String str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }

        public static String FromBase64(this String str)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(str));
        }
	}
}