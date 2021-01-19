using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPatternAPP.Data
{
    public class Student : BaseEntity
    {
        [Required]
        public string S_FirstName { get; set; }
        [Required]
        public string S_LastName { get; set; }
        [Required]
        public string S_Email { get; set; }
        [Required]
        public string S_EnrollmentNo { get; set; }
    }
}
