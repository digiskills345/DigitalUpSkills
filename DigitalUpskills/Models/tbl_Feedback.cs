namespace DigitalUpskills.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[tbl.Feedback]")]
    public partial class tbl_Feedback
    {
        [Key]
        public int Feedback_Id { get; set; }

        [StringLength(50)]
        public string Feedback_Description { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Feedback_Rating { get; set; }

        public int Student_Fid { get; set; }

        public virtual tbl_Student tbl_Student { get; set; }
    }
}
