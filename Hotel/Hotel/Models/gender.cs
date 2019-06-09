using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel
{
    public enum gender
    {
        [Display(Name ="خانم")]
        Female,
        [Display(Name = "آقا")]
        Male
    }
}