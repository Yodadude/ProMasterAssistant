using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProMasterAssistant.Controllers
{
    public class BaseController : Controller
    {
        public int MyProperty { get; set; }
        
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }
    }
}