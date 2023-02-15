using DigitalUpskills.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalUpskills.Utills
{
    public static class CurrentUser
    {
        public static tbl_Student CurrentStudent { get; set; }
        public static tbl_Instructor Currentinstructor { get; set; }
    }
}