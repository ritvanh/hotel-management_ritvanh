using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManager.Models
{
    public class PersonAddRequest
    {
        [Required]
        [StringLength(50)]
        [Display(Name ="Emer")]
        public string Name { get; set; }
        [Display(Name = "Mbiemer")]
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(200)]
        [DataType(DataType.Password)]
        [Display(Name = "Fjalekalim")]
        public string Password { get; set; }
        [Display(Name = "Roli")]
        [Required]
        public Role Role { get; set; }
    }
}