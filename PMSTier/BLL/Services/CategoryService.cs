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
    public class CategoryService
    {
        static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Category,CategoryDTO>();
                cfg.CreateMap<CategoryDTO, Category>();
            });
            return new Mapper(config);
        }
        public static bool Create(CategoryDTO obj) { 
            var data = GetMapper().Map<Category>(obj);
            return DataAccess.CategoryData().Create(data);
        }
        public static List<CategoryDTO> Get() {
            var data = DataAccess.CategoryData().Get();
            return GetMapper().Map<List<CategoryDTO>>(data);
        }
        public static CategoryDTO Get(int id) {
            var data = DataAccess.CategoryData().Get(id);
            return GetMapper().Map<CategoryDTO>(data);
        }
        public static bool Update(CategoryDTO obj) {
            var data = GetMapper().Map<Category>(obj);
            return DataAccess.CategoryData().Update(data);
        }
        public static bool Delete(int id) {
            return DataAccess.CategoryData().Delete(id);
        }
    }
}
