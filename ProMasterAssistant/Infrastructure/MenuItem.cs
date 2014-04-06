using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProMasterAssistant.Infrastructure
{
    public class MenuItem
    {
        public string Text { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public bool Selected { get; set; }
    }
}
