namespace DigitalUpskills.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[tbl.Course]")]
    public partial class tbl_Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Course()
        {
            tbl_CourseRegistration = new HashSet<tbl_CourseRegistration>();
            tbl_Lecture = new HashSet<tbl_Lecture>();
            tbl_Slide = new HashSet<tbl_Slide>();
            tbl_Feedback = new HashSet<tbl_Feedback>();
            tbl_Bookmark = new HashSet<tbl_Bookmark>();
        }

        [Key]
        public int Course_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Course_Name { get; set; }

        [Required]
        public Boolean Is_Approved { get; set; }

        [Required]
        [StringLength(50)]
        public string Course_Code { get; set; }

        [StringLength(300)]
        public string Course_Detail { get; set; }

        public int Course_Fee { get; set; }

        [Required]
        [StringLength(50)]
        public string Course_Duration { get; set; }

       
        public string Course_Image { get; set; }

        public int Instructor_Fid { get; set; }
        public int CourseCategory_Fid { get; set; }

        public virtual tbl_CourseCategory tbl_CourseCategory { get; set; }

        public virtual tbl_Instructor tbl_Instructor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_CourseRegistration> tbl_CourseRegistration { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Lecture> tbl_Lecture { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Slide> tbl_Slide { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Feedback> tbl_Feedback { get; set; } 
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Bookmark> tbl_Bookmark { get; set; }
    }
}
