namespace DigitalUpskills.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[tbl.Student]")]
    public partial class tbl_Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Student()
        {
            tbl_CourseRegistration = new HashSet<tbl_CourseRegistration>();
            tbl_Feedback = new HashSet<tbl_Feedback>();
        }

        [Key]
        public int Student_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Student_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Student_CNIC { get; set; }

        [Required]
        [StringLength(50)]
        public string Student_Gmail { get; set; }

        [Required]
        [StringLength(50)]
        public string Student_Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Student_PhoneNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Student_Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CourseRegistration> tbl_CourseRegistration { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Feedback> tbl_Feedback { get; set; }
    }
}
