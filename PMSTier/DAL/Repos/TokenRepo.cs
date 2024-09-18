using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, IRepo<Token, string, Token>
    {
        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(string id)
        {
            var exobj = Get(id);
            db.Tokens.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public Token Get(string id)
        {
            return db.Tokens.SingleOrDefault(t=>t.Key.Equals(id));
        }

        public Token Update(Token obj)
        {
            var exobj = Get(obj.Key);
            //db.Entry(exobj).CurrentValues.SetValues(obj);
            exobj.ExpiredAt = obj.ExpiredAt;
            db.SaveChanges() ;
            return obj; ;
        }
    }
}
