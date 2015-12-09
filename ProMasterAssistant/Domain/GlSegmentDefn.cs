using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPoco;

namespace ProMasterAssistant.Domain
{
    [TableName("gl_segment_defn")]
    [PrimaryKey("gl_type, segment_id", AutoIncrement = false)]
    public class GlSegmentDefinition
    {
        [Column("gl_type")]
        public string GlType { get; set; }
        [Column("segment_id")]
        public int SegmentId { get; set; }
        [Column("error_text")]
        public string ErrorText { get; set; }
        [Column("label")]
        public string Label { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("char_limit")]
        public int CharLimit { get; set; }
        [Column("width")]
        public int Width { get; set; }
        [Column("data_type")]
        public string DataType { get; set; }
        [Column("validation_type")]
        public string ValidationType { get; set; }
        [Column("search_sql")]
        public string SearchSql { get; set; }
        [Column("row_warn")]
        public int? RowWarn { get; set; }
        [Column("search_win_defn")]
        public string SearchWinDefn { get; set; }
    }
}