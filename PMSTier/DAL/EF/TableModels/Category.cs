using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Category
    {
        public int Id { get; set; }
        [StringLength(10)]
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Product>Products { get; set; }
        public Category() { 
            Products = new List<Product>();
        }
    }
}
