using NPoco;

namespace ProMasterAssistant.Domain
{
    [TableName("gl_type")]
    [PrimaryKey("gl_type, autoIncrement = false")]
    public class GlType
    {
        [Column("gl_type")]
        public string Type { get; set; }
        [Column("delimiter")]
        public string Delimiter { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("status")]
        public string Status { get; set; }
        [Column("tab_no")]
        public int? TabNo { get; set; }
        [Column("validation_type")]
        public string ValidationType { get; set; }
    }
}