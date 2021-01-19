using RepositoryPatternAPP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPatternAPP.Models
{
    public interface IStudentRepository
    {
        void SaveStudent(Student student);
        IEnumerable<Student> GetAllStudents();
        Student GetStudent(Int32 id);
        void DeleteStudent(Int32 id);
        void UpdateStudent(Student student);
    }
}
