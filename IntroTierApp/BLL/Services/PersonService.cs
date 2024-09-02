using AutoMapper;
using BLL.DTOs;
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
        public static List<PersonDTO> GetAll() {
            var data = PersonRepo.Get(); //Ef models
            var conf = new MapperConfiguration(cfg => { 
                cfg.CreateMap<Person,PersonDTO>();
            });
            var mapper = new Mapper(conf);
            return mapper.Map<List<PersonDTO>>(data);
           
        }
        public static PersonDTO Get(int id)
        {
            var data = PersonRepo.Get(id); //Ef models
            var conf = new MapperConfiguration(cfg => {
                cfg.CreateMap<Person, PersonDTO>();
            });
            var mapper = new Mapper(conf);
            return mapper.Map<PersonDTO>(data);

        }
    }
}
