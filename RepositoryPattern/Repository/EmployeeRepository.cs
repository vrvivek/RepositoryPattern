using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext contextEmployeeDB;
        
        public EmployeeRepository()
        {
            contextEmployeeDB = new EmployeeDBContext();
        }

        public EmployeeRepository(EmployeeDBContext context)
        {
            contextEmployeeDB = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return contextEmployeeDB.Employees.ToList();
        }

        public Employee GetById(int NumE_ID)
        {
            return contextEmployeeDB.Employees.Find(NumE_ID);
            //return contextEmployeeDB.Employees.SingleOrDefault(e=>e.EID==NumE_ID);
        }

        public void Insert(Employee employee)
        {
            contextEmployeeDB.Employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            contextEmployeeDB.Entry(employee).State = EntityState.Modified;
        }

        public void Delete(int NumE_ID)
        {
            Employee employee = contextEmployeeDB.Employees.Find(NumE_ID);
            contextEmployeeDB.Employees.Remove(employee);
        } 

        public void Save()
        {
            contextEmployeeDB.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    contextEmployeeDB.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
