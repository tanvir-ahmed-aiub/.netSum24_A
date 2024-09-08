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
    public class DepartmentService
    {
        Mapper getMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Department, DepartmentDTO>();
                cfg.CreateMap<DepartmentDTO, Department>();
            });
            var mapper = new Mapper(config);
            return mapper;
        }
        public static List<DepartmentDTO> Get() {
            var data = DataAccessFactory.DepartmentData().Get();
            var mapper = getMapper();
            var retData = mapper.Map<List<DepartmentDTO>>(data);
            return retData;
        }
    }
}
