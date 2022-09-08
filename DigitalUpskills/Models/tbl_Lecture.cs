namespace DigitalUpskills.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[tbl.Lecture]")]
    public partial class tbl_Lecture
    {
        [Key]
        public int Lecture_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Lecture_Name { get; set; }

        [StringLength(200)]
        public string Lecture_Detail { get; set; }

        public int Is_Demo { get; set; }

        [Required]
        public string Video_Lecture_Path { get; set; }

        public int Course_Fid { get; set; }

        public virtual tbl_Course tbl_Course { get; set; }
    }
}
