using DAL.EF;
using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PersonRepo : Repo, IRepo<Person, int, bool>
    {
        public bool Add(Person obj)
        {
            db.Persons.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Persons.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Person> Get()
        {
            return db.Persons.ToList();
        }

        public Person Get(int id)
        {
            return db.Persons.Find(id);
        }

        public bool Update(Person obj)
        {
            var exobj = Get(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
