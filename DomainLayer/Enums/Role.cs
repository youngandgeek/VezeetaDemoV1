using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Enums
{
    public enum Role
    {
        [Display(Name = "Admin")]
        Admin,
        [Display(Name ="Patient")]
        Patient,
        [Display(Name ="Doctor")]
        Doctor
    }
}
