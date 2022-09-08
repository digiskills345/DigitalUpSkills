namespace DigitalUpskills.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[tbl.Slide]")]
    public partial class tbl_Slide
    {
        [Key]
        public int Slide_Id { get; set; }

        [Required]
        public string Slide_Name { get; set; }

        [Required]
        public string Slide_Detail { get; set; }

        public int Course_Fid { get; set; }

        public virtual tbl_Course tbl_Course { get; set; }
    }
}
