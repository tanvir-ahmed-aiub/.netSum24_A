using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Token, TokenDTO>();
               
            });
            return new Mapper(config);
        }
        public static TokenDTO Authenticate(string uname, string pass) { 
            var data = DataAccess.AuthData().Authenticate(uname, pass);
            if (data) {
                Token t = new Token();
                t.CreatedAt = DateTime.Now;
                t.Key = Guid.NewGuid().ToString();
                t.Uname = uname;
                var token = DataAccess.TokenData().Create(t);
                return GetMapper().Map<TokenDTO>(token);
            }
            
            return null;
        }
        public static bool LogoutToken(string key) {
            if (DataAccess.TokenData().Get(key) != null) {
                Token token = new Token();
                token.Key = key;
                token.ExpiredAt = DateTime.Now;
                var ret = DataAccess.TokenData().Update(token);
                return ret != null;
            }
            

            return false;

        
        }
        public static bool IsTokenValid(string key) { 
            var token = DataAccess.TokenData().Get(key);
            if (token != null && token.ExpiredAt == null) return true;
            return false;
        }
        public static bool IsTokenValidAdmin(string key) {
            var token = DataAccess.TokenData().Get(key);
            if (token != null && token.ExpiredAt == null &&
                token.User.Role.Equals("Admin")) return true;
            return false;

        }

    }
}
