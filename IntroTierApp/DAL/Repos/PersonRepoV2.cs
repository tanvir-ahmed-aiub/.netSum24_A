using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PersonRepoV2 : Repo,IRepo<Person,int,bool>
    {
        public static List<Person> GetAllPerson() {

            return new List<Person>() { new Person() { Id = 1, Name = "P1" };
        }
        public static Person GetPerson(int id) {
            return new Person() { Id = id, Name = "P1" };
        }

        public bool Add(Person obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> Get()
        {
            throw new NotImplementedException();
        }

        public Person Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Person obj)
        {
            throw new NotImplementedException();
        }
    }
}
