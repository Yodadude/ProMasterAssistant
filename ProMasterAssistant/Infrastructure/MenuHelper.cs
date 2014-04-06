using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProMasterAssistant.Infrastructure
{
    public class MenuHelper
    {
        public static List<MenuItem> SetActive(ControllerContext context, List<MenuItem> items)
        {

            string action = context.ParentActionViewContext.RouteData.Values["action"].ToString();
            string controller = context.ParentActionViewContext.RouteData.Values["controller"].ToString();

            foreach (var item in items)
            {
                if (item.Controller == controller && item.Action == action)
                {
                    item.Selected = true;
                }
            }

            return items;
        }
    }
}