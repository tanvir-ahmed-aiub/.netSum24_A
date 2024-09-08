using DAL.EF.TableModels;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Person,int,bool> PersonData() {
            return new PersonRepo();
        }
        public static IRepo<Department, int, Department> DepartmentData() {
            return new DepartmentRepo();
        }
        
    }
}
