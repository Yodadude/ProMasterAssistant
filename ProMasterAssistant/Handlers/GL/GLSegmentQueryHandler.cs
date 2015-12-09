using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPoco;
using ProMasterAssistant.Domain;
using ProMasterAssistant.Infrastructure;

namespace ProMasterAssistant.Handlers.GL
{
    public class GLSegmentQueryHandler : ICommandHandler<GLSegmentQueryModel, GLSegmentViewModel>
    {
        private IDatabase _database;

        public GLSegmentQueryHandler(IDatabase database)
        {
            _database = database;
        }

        public GLSegmentViewModel Handle(GLSegmentQueryModel model)
        {
            var sql = @"select gl_type from gl_type where status = active";

            string glType = _database.ExecuteScalar<string>(sql);

            sql = @"select * from gl_segment_defn where gl_type = {0}";

            var rows = _database.Fetch<GlSegmentDefinition>(sql, model.GlType ?? glType).ToList();

            return new GLSegmentViewModel { Segments = rows };
        }
    }
}