using NPoco;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ProMasterAssistant.Infrastructure;
using StructureMap;

namespace ProMasterAssistant.Controllers
{
    public class BaseController : Controller
    {
        public IDatabase DataContext { get; set; }
        public ICommandInvoker Command { get; set; }

        public BaseController() : this(ObjectFactory.GetInstance<IDatabase>(), ObjectFactory.GetInstance<ICommandInvoker>())
        {
        }

        public BaseController(IDatabase database, ICommandInvoker invoker)
        {
            DataContext = database;
            Command = invoker;
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }
    }
}