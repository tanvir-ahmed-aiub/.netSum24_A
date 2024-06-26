﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMSDemo.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string Uname { get; set; }
        [Required]
        public string Password { get; set; }
    }
}