using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntroMVC.Models
{
    public class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Profession { get; set; }

        public int Id { get; set; }
        public float Cgpa { get; set; }

    }
}