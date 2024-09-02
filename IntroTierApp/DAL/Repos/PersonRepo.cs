using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class PersonRepo
    {
        public static List<Person> Get() {
            List<Person> list = new List<Person>();
            list.Add(new Person() { Id = 1, Name = "P1"});
            list.Add(new Person() { Id = 2, Name = "P2"});
            
            return list;
        }
        public static Person Get(int id) {
            var p = new Person() { Id = id, Name="P"+id};
            return p;
        }
    }
}
