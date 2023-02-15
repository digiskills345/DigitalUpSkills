namespace DigitalUpskills.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[tbl.CourseCategory]")]
    public partial class tbl_CourseCategory
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_CourseCategory()
        {
            tbl_Course = new HashSet<tbl_Course>();
 
        }
        [Key]
        public int CourseCategory_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseCategory_Name { get; set; }

        [StringLength(200)]
        public string CourseCategory_Details { get; set; }

        [Required]
        public string CourseCategory_Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Course> tbl_Course { get; set; }



    }
}
