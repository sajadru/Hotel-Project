using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel
{
    public class Room
    {
        public int Id { get; set; }
        [Display(Name = "نوع‌اتاق")]
        public string Kind { get; set; }
        [Display(Name = "شماره‌اتاق")]
        public int Number { get; set; }
        [Display(Name = "قیمت")]
        public int Price { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "وضعیت‌اتاق")]
        public reserve Reserve { get; set; }
    }
}