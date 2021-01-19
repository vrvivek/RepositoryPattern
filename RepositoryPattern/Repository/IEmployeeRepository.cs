using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Repository
{
    interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int NumE_ID);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(int NumE_ID);
        void Save();
    }
}
