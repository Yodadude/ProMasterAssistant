using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProMasterAssistant.Models
{
	public class ConnectionSettingsModel
	{
		public string ConnectionName { get; set; }
		public string Server { get; set; }
		public string Database { get; set; }
		public string UserId { get; set; }
		public string Password { get; set; }
	}
}