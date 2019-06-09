using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Hotel.Models;
namespace Hotel
{
    public class Person
    {
       
        public int Id { get; set; }
        [Display(Name ="نام")]
        public string Name { get; set; }
        [Display(Name = "نام‌خانوادگی")]
        public string Family { get; set; }
        [Display(Name = "کد‌ملی")]
        public int NathionalCode { get; set; }
        [Display(Name = "شماره‌تماس")]
        public int Phone { get; set; }
        [Display(Name = "سن")]
        public int Age { get; set; }
        [Display(Name = "جنسیت")]
        public gender Gender { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}