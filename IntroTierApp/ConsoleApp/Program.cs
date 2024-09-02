using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = PersonService.Get(109);
            Console.WriteLine(data.Name+" "+data.Id);
        }
    }
}
