using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPoco;
using ProMasterAssistant.Infrastructure;

namespace ProMasterAssistant.Handlers.GL
{
    public class GLTypeListHandler : ICommandHandler<GLTypeListQueryModel, GLTypeListViewModel>
    {
        private IDatabase _database;

        public GLTypeListHandler(IDatabase database)
        {
            _database = database;
        }

        public GLTypeListViewModel Handle(GLTypeListQueryModel model)
        {
            var sql = @"select * from gl_type";

            var rows = _database.Fetch<Domain.GlType>(sql);

            return new GLTypeListViewModel { GlTypes = rows };
        }
    }

    public class GLTypeListQueryModel
    {
    }

    public class GLTypeListViewModel
    {
        public List<Domain.GlType> GlTypes { get; set; }
    }
}