namespace DigitalUpskills.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Services.Description;

    [Table("[tbl.Message]")]
    public partial class tbl_Message
    {
        [Key]
        public int Message_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        
        public string MessageBody { get; set; }

       
        [StringLength(300)]
        public string Subject { get; set; }
     
    }
}
