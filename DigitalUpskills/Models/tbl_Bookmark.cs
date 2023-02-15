namespace DigitalUpskills.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[tbl.Bookmark]")]
    public partial class tbl_Bookmark
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]


        [Key]
        public int Bookmark_Id { get; set; }

        public int Course_Fid { get; set; }

        public int Student_Fid { get; set; }

        public virtual tbl_Student tbl_Student{ get; set; }
        public virtual tbl_Course tbl_Course{ get; set; }
    }
}
