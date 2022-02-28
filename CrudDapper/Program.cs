using CrudDapper.Data.IRepositories;
using CrudDapper.Data.Repositories;
using System;

namespace CrudDapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUniversityRepository univerRepo = new UniversityRepository();
           
            IStudentRepository studentRepo = new StudentRepository();

            var st = studentRepo.GetAsync(1).Result;

            var un = univerRepo.GetAsync(1).Result;

            Console.WriteLine(un.Id + " " + un.Name + " " + un.Groups[0].Name);
            
            Console.WriteLine(st.Id + " " + st.FullName + " " + st.Group.Name);
        }
    }
}