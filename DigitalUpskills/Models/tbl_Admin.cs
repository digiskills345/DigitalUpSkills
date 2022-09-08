namespace DigitalUpskills.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[tbl.Admin]")]
    public partial class tbl_Admin
    {
        [Key]
        public int Admin_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Admin_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Admin_CNIC { get; set; }

        [Required]
        [StringLength(50)]
        public string Admin_PhoneNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Admin_Gmail { get; set; }

        [Required]
        [StringLength(200)]
        public string Admin_Address { get; set; }

        [Required]
        [StringLength(50)]
        public string Admin_Password { get; set; }
    }
}
