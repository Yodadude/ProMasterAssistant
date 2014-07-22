using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPoco;

namespace ProMasterAssistant.Infrastructure
{
    public interface IDatabaseFactory
    {
        IDatabase Create();
    }

    public class DatabaseFactory : IDatabaseFactory
    {
        public IDatabase Create()
        {
            var connectionStringName = HttpContext.Current.Request.Cookies["ConnectionStringName"].Value;

            var db = new Database(connectionStringName);

            return db;
        }
    }
}