using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Models
{
    public class Employee
    {
        [Key]
        public int EID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string EName { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 4)]
        public string EGender { get; set; }
        public Nullable<int> ESalary { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string EDept { get; set; }
    }
}
