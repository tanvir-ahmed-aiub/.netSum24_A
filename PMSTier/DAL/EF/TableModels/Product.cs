using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Category Category { get; set; }
        [ForeignKey("Category")]
        public int PId { get; set; }
    }
}
