namespace DigitalUpskills.Models
{
    using DigitalUpskills.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[tbl.Instructor]")]
    public partial class tbl_Instructor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Instructor()
        {
            tbl_Course = new HashSet<tbl_Course>();
        }

        [Key]
        public int Instructor_Id { get; set; }

        public string Instructor_Image { get; set; }

        [Required]
        [StringLength(50)]
        public string Instructor_Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Instructor_CNIC { get; set; }
        [Required]
        [StringLength(50)]
        public string Instructor_Qualification { get; set; }
        [Required]
        [StringLength(50)]
        public string Instructor_PhoneNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Instructor_Gmail { get; set; }

        [Required]
        [StringLength(200)]
        public string Instructor_Address { get; set; }
        [Required]
        [StringLength(500)]
        public string Instructor_Detail { get; set; }
        [Required]
        [StringLength(50)]
        public string Instructor_Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Course> tbl_Course { get; set; }
    }
}
