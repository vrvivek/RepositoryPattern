using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryPatternAPP.Data
{
    public class StudentMap
    {
        public StudentMap(EntityTypeBuilder<Student> entityBuilder)
        {
            entityBuilder.HasKey(t => t.ID);
            entityBuilder.Property(t => t.S_FirstName).IsRequired();
            entityBuilder.Property(t => t.S_LastName).IsRequired();
            entityBuilder.Property(t => t.S_Email).IsRequired();
            entityBuilder.Property(t => t.S_EnrollmentNo).IsRequired();
        }
    }
}
