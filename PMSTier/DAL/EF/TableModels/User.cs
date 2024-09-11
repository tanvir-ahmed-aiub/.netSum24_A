using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class User
    {
        [Key]
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        public string Username { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
