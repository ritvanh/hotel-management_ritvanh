using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManager.Models
{
    public class PersonLoginRequest
    {
        [Required]
        [EmailAddress]
        [Display(Name ="EMail")]
        public string Email { get; set; }
        [Display(Name ="Fjalekalimi")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}