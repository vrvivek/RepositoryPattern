using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPatternAPP.Data
{
    public class Student : BaseEntity
    {
        public string S_FirstName { get; set; }
        public string S_LastName { get; set; }
        public string S_Email { get; set; }
        public string S_EnrollmentNo { get; set; }
    }
}
