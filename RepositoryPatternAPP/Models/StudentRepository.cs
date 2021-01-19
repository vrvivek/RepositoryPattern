﻿using Microsoft.EntityFrameworkCore;
using RepositoryPatternAPP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPatternAPP.Models
{
    public class StudentRepository : IStudentRepository
    {
        private ApplicationContext context;
        private DbSet<Student> studentEntity;
        public StudentRepository(ApplicationContext context)
        {
            this.context = context;
            studentEntity = context.Set<Student>();
        }


        public void SaveStudent(Student student)
        {
            context.Entry(student).State = EntityState.Added;
            context.SaveChanges();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return studentEntity.AsEnumerable();
        }

        public Student GetStudent(Int32 id)
        {
            return studentEntity.SingleOrDefault(s => s.ID == id);
        }
        public void DeleteStudent(Int32 id)
        {
            Student student = GetStudent(id);
            studentEntity.Remove(student);
            context.SaveChanges();
        }
        public void UpdateStudent(Student student)
        {
            context.SaveChanges();
        }
    }
}
