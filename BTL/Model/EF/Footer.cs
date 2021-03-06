namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Footer")]
    public partial class Footer
    {
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        public string Text { get; set; }

        [StringLength(10)]
        public string Link { get; set; }

        [StringLength(10)]
        public string TypeID { get; set; }

        [StringLength(10)]
        public string Target { get; set; }

        public bool Status { get; set; }
    }
}
