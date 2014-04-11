using NPoco;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProMasterAssistant.Controllers
{
    public class BaseController : Controller
    {
        public Database DataContext { get; private set; }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            var connectionStringName = requestContext.HttpContext.Request.Cookies["ConnectionStringName"].Value;

            DataContext = new Database(connectionStringName);
        }
    }
}