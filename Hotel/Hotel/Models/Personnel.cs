using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel
{
    public class Personnel : Person
    {
        public int Id { get; set; }
        [Display(Name = "شماره‌پرسنلی")]
        public int PersonnelCode { get; set; }
        [Display(Name = "درجه")]
        public string Degree { get; set; }
        [Display(Name = "سابقه‌کاری")]
        public int WorkExperience { get; set; }

    }
}