using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, string, User>,IAuth
    {
        public User Create(User obj)
        {
            db.Users.Add(obj);
            db.SaveChanges();
            return obj;

        }

        public bool Delete(string id)
        {
            var exobj = Get(id);
            db.Users.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(string id)
        {
            return db.Users.Find(id);
        }

        public User Update(User obj)
        {
            var exobj = Get(obj.Username);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return obj;

        }
        public bool Authenticate(string uname, string pass) {
            var user = db.Users.SingleOrDefault(
                    u=> u.Username.Equals(uname) &&
                    u.Password.Equals(pass)
                );
            return user != null;
        }
    }
}
