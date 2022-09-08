namespace DigitalUpskills.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[tbl.CourseRegistration]")]
    public partial class tbl_CourseRegistration
    {
        [Key]
        public int Course_Registraion_Id { get; set; }

        [StringLength(200)]
        public string Course_Registration_Detail { get; set; }

        [Required]
        [StringLength(50)]
        public string Payment_Mode { get; set; }

        public DateTime Registration_Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public int Student_Fid { get; set; }

        public int Course_Fid { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Gmail { get; set; }

        [Required]
        [StringLength(300)]
        public string Address { get; set; }

        public virtual tbl_Course tbl_Course { get; set; }

        public virtual tbl_Student tbl_Student { get; set; }
    }
}
