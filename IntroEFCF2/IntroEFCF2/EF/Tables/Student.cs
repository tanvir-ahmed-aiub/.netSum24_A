using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntroEFCF2.EF.Tables
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [StringLength(10)]
        [Required]
        [Column(TypeName ="VARCHAR")]
        public string Name { get; set; }
        [StringLength(500)]
        [Required]
        public string Address { get; set; }
    }
}