using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormHandling.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Please Provide Username")]
        [StringLength(10,MinimumLength =4)]
        public string Uname { get; set; }
        [Required]
        public string Pass { get; set; }
    }
}