using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel
{
    public class Referred : Person
    {
        public int Id { get; set; }
        [Display(Name = "شماره‌اتاق")]
        public int RoomNumber { get; set; }
        [Display(Name = "مدت‌استقرار")]
        public int StayingTime { get; set; }

    }
}