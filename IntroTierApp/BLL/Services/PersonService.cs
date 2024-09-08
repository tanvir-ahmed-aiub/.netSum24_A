using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.TableModels;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PersonService
    {
        static Mapper GetMapper() {
            var conf = new MapperConfiguration(cfg => {
                cfg.CreateMap<Person, PersonDTO>();
                cfg.CreateMap<PersonDTO, Person>();
            });
            return new Mapper(conf);
        }
        public static List<PersonDTO> GetAll() {
            //var data = PersonRepo.Get(); //Ef models
            var data = DataAccessFactory.PersonData().Get();
            return GetMapper().Map<List<PersonDTO>>(data);
           
        }
        public static PersonDTO Get(int id)
        {
            //throw new NotImplementedException();
            var data = DataAccessFactory.PersonData().Get(id); //Ef models
            return GetMapper().Map<PersonDTO>(data);

        }
        public static bool Create(PersonDTO p) {
            
            var data = GetMapper().Map<Person>(p);
            return DataAccessFactory.PersonData().Add(data);

        }

    }
}
