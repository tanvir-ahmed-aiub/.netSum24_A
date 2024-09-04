using DAL.EF;
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
        static Context db = new Context();
        public static List<Person> Get() {
            return db.Persons.ToList();
        }
        public static Person Get(int id) {
            //var person = db.Persons.SingleOrDefault(x=> x.Id == id);
            return db.Persons.Find(id);
        }
        public static bool Create(Person p) {
            db.Persons.Add(p);
            return db.SaveChanges() > 0;
        }
        public static bool Update(Person p) {
            var exobj = Get(p.Id);
            db.Entry(exobj).CurrentValues.SetValues(p);
            return db.SaveChanges() > 0;
        }
        public static bool Delete(int id) {
            var exobj = Get(id);
            db.Persons.Remove(exobj);
            return db.SaveChanges() > 0;
        }
        

    }
}
